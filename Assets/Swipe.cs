using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    Vector2 startTouchPosition;
    Vector2 endTouchPosition;

    void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            endTouchPosition = Input.GetTouch(0).position;

            if(endTouchPosition.y > startTouchPosition.y)
            {
                SwipeUp();
            }
            if(endTouchPosition.y < startTouchPosition.y)
            {
                SwipeDown();
            }
        }

        void SwipeUp()
        {
            //flap up
            Debug.Log("flap up");
        }

        void SwipeDown()
        {
            Debug.Log("flap down");
        }


    }
}
