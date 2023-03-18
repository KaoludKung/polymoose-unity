using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private AudioSource footStep;
    private Animator animator;
    private Vector2 target;

    private bool isMoving;
    private bool isRotating;
    private bool facingRight = true;

    public bool isInteract = false;
    public int levelID;

    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ToMove();
    }

    void TouchMovement()
    {
        Vector2 CurrentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            
            if (hit.collider.tag == "object")
            {
                if (isInteract)
                {
                   StartCoroutine(ChangeScene("Loading"));
                }
            }
            else if(hit.collider.tag == "background" && !IsPointerOverUIObject())
            {
                target = new Vector2(CurrentPosition.x, transform.position.y);
                isMoving = true;
                isRotating = true;
            }
        }

        if (isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
            footStep.enabled = true;
            animator.SetBool("ISWALK", true);

            if (transform.position.x == target.x)
            {
                isMoving = false;
                isRotating = false;
            }
        }
        else
        {
            footStep.enabled = false;
            animator.SetBool("ISWALK", false);
        }

        if (isRotating)
        {
            if (target.x > transform.position.x && !facingRight)
            {
                FlipCharacter();
            }
            else if (target.x < transform.position.x && facingRight)
            {
                FlipCharacter();
            }
        }
    }

    void FlipCharacter()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    void ToMove()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 CurrentPosition = Camera.main.ScreenToWorldPoint(touch.position);

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);

            if (hit.collider.tag == "object")
            {
                isMoving = false;

                if (isInteract)
                {
                    PlayerPrefs.SetInt("Loading", levelID);
                    StartCoroutine(ChangeScene("Loading"));
                }
            }
            else if (hit.collider.tag == "background" && !IsPointerOverUIObject())
            {
                target = new Vector2(CurrentPosition.x, transform.position.y);
                isMoving = true;
                isRotating = true;
            }


            if (isMoving)
            {
                target = new Vector2(CurrentPosition.x, transform.position.y);
                transform.position = Vector2.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
                footStep.enabled = true;
                animator.SetBool("ISWALK", true);
            }

            if (target.x > transform.position.x && !facingRight)
            {
                FlipCharacter();
            }
            else if (target.x < transform.position.x && facingRight)
            {
                FlipCharacter();
            }
        }
        else
        {
            footStep.enabled = false;
            animator.SetBool("ISWALK", false);
        }

    }

    IEnumerator ChangeScene(string sceneID)
    {
        yield return new WaitForSeconds(0f);
        SceneManager.LoadScene(sceneID);
    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
