using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeFunctionality : MonoBehaviour
{
    private Vector2 fingerDown;
    private Vector2 fingerUp;
    float swipeThreshold = 50f;

    void Start()
    {
        fingerDown = fingerUp;
    }


    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                fingerDown = touch.position;
                
            }
            if(touch.phase == TouchPhase.Moved)
            {
                fingerUp = touch.position;
                //checkSwipe();
            }
            if(touch.phase == TouchPhase.Ended)
            {
                fingerUp = touch.position;
                checkSwipe();
            }
        }
    }

    void checkSwipe()
    {
        if(VerticalSwipeLength() > swipeThreshold && VerticalSwipeLength() > HorizontalSwipeLength())
        {
            if (fingerDown.y - fingerUp.y > 0)
                Debug.Log("SwipeDown");
            if (fingerDown.y - fingerUp.y < 0)
                Debug.Log("SwipeUp");
        }

        else if(HorizontalSwipeLength() > swipeThreshold && HorizontalSwipeLength() > VerticalSwipeLength())
        {
            if (fingerDown.x - fingerUp.x > 0)
                Debug.Log("SwipeLeft");
            if (fingerDown.x - fingerUp.x < 0)
                Debug.Log("SwipeRight");
        }
    }

    float VerticalSwipeLength()
    {
        return Mathf.Abs(fingerDown.y - fingerUp.y);
    }

    float HorizontalSwipeLength()
    {
        return Mathf.Abs(fingerDown.x - fingerUp.x);
    }
}
