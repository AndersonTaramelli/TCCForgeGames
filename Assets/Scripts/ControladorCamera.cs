using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class ControladorCamera : MonoBehaviour
{
    [SerializeField] private AxisState xAxis;
    [SerializeField] private AxisState yAxis;

    [SerializeField] private Transform LookAt;

    private Touch theTouch;

    private Vector2 touchStartPosition, touchEndPosition;

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);

            if (theTouch.phase == TouchPhase.Began)
            {
                touchStartPosition = theTouch.position;
            }
            else if (theTouch.phase == TouchPhase.Moved || theTouch.phase == TouchPhase.Ended)
            {
                touchEndPosition = theTouch.position;

                float x = touchEndPosition.x - touchStartPosition.x;
                float y = touchEndPosition.y - touchStartPosition.y;

                if (Mathf.Abs(x) == 0 && Mathf.Abs(y) == 0)
                {
                    direction = “Tapped”;
                }

                else if (Mathf.Abs(x) > Mathf.Abs(y))
                {
                    direction = x > 0 ? “Right” : “Left”;
                }

                else
                {
                    direction = y > 0 ? “Up” : “Down”;
                }
            }
        }

        directionText.text = direction;
    }
    }
}
