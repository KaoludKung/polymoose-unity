using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class SideScroller : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private AudioSource footStep;
    private Vector2 target;

    private bool isMoving;
    private bool isRotating;
    private bool facingRight = true;

    public bool isInteract = false;

    // Update is called once per frame
    void Update()
    {
        TouchMovement();
    }

    void TouchMovement()
    {
        Vector2 CurrentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonUp(0) && !IsPointerOverUIObject())
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider.tag == "interact")
            {
                if (isInteract)
                {
                    Debug.Log("This is interact object");
                }
            }
            else
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
            //animator.SetBool("IsMoving", true);

            if (transform.position.x == target.x)
            {
                isMoving = false;
                isRotating = false;
            }
        }
        else
        {
            footStep.enabled = false;
            //animator.SetBool("IsMoving", false);
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

            if (!IsPointerOverUIObject())
            {
                target = new Vector2(CurrentPosition.x, transform.position.y);
                transform.position = Vector2.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
                footStep.enabled = true;
                //animator.SetBool("IsMoving", true);
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
            //animator.SetBool("IsMoving", false);
        }

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
