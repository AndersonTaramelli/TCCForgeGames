using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    [SerializeField]
    private Vector3 offset;

    [Range(0, 1)]
    public float safe = 0.2f;
    public Transform player;

    public Transform Aster;

    public float TouchX;

    void update()
    {
        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase != TouchPhase.Began)
            {
                if (TouchX == -1)
                {
                    TouchX = Input.GetTouch(0).position.x;
                }
                else
                {
                    TouchX = TouchX - Input.GetTouch(0).position.x;
                }
                    
            }
                
            if (TouchX != 0)
            {
                rot(TouchX);

                TouchX = Input.GetTouch(0).position.x;
            }
        }
        else
        TouchX = -1;
    }

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.position + offset, safe);
    }

    void rot(float direcao)
    {
        if (direcao > 0)
        {
            transform.RotateAround(Aster.position, Vector3.up, 90 * Time.deltaTime);
        }
        else
        {
            transform.RotateAround(Aster.position, Vector3.up, -90 * Time.deltaTime);
        }
    }
}
