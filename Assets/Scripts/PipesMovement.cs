using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesMovement : MonoBehaviour
{

    public Swipe swipe;

    public float pipeMoveSpeed = 5f;
    private float leftEdge;

    private void Start() 
    {
        swipe = FindObjectOfType<Swipe>();
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    private void Update() 
    {
        transform.position += Vector3.left * pipeMoveSpeed * Time.deltaTime;

        if(transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }

        if (swipe.isDead == true)
        {
            Destroy(gameObject);
        }
    }

}
