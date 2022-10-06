using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{

    public Rigidbody2D playerRigidbody;
    public CircleCollider2D circleCollider;

    public GameManager gameManager;
    public Animator animator;

    public ParticleSystem confeti;

    public float swipeLength;
    public float finalForce;
    public float gravity = -9.8f;

    public int scoreCounter;

    public bool isDead;

    //gets screen positions for both start and end of swipe
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    private Vector2 finalMagnitude;

    private Vector3 direction;

    private void Awake()
    {
        confeti = GetComponentInChildren<ParticleSystem>();
        playerRigidbody.isKinematic = true;
        circleCollider.isTrigger = true;
        animator.enabled = true;
        scoreCounter = 0;
    }

    void Update()
    {
        if(gameManager.isStarted == false)
        {
            return;
        } 

        if(gameManager.isFinished == true)
        {
            return;
        }


        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)// checks if its the first touch 
        {
            startTouchPosition = Input.GetTouch(0).position; //sets the vector2 as the initial touch position 
            swipeLength = 0;
        }

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) // checks the last position touched
        {
            endTouchPosition = Input.GetTouch(0).position; //sets the vector2 as the last touched position
            finalMagnitude = startTouchPosition - endTouchPosition;
            swipeLength = finalMagnitude.magnitude;

            finalForce = swipeLength / 100;
            Mathf.Clamp(finalForce, 0, 10);

            if(endTouchPosition.y > startTouchPosition.y) // checks if end position is positive
            {
                SwipeUp(); //calls the actual up swiping function
            }
            if(endTouchPosition.y < startTouchPosition.y) //checks if the end position is negative
            {
                SwipeDown(); //calls the actual down swiping function
            }

        }

        
            direction.y += gravity * Time.deltaTime;
            transform.position += direction * Time.deltaTime;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Obstacles"))
        {
            playerRigidbody.isKinematic = false;
            circleCollider.isTrigger = false;
            gameManager.isFinished = true;
            animator.enabled = false;
            isDead = true;
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Score"))
        {
            scoreCounter++;
            confeti.Play();
        }
    }

    void SwipeUp()
    {
        direction = Vector3.up * finalForce;
        Debug.Log("flap up");
    }

    void SwipeDown()
    {
        direction = Vector3.down * finalForce;
        Debug.Log("flap down");
    }


}
