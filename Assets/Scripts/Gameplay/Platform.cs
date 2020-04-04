using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    //private float leftBound = -3.36f, rightBound = 3.36f; // S size 0.4
    //private float leftBound = -2.89f, rightBound = 2.89f; // M size 0.7
    private float leftBound = -2.43f, rightBound = 2.43f; // L size 1
    
    private float speed = 1f; // slow
    //private float speed = 2f; // medium
    //private float speed = 3f; // fast

    private bool left;
    
    void Awake()
    {
        PlatformMovement();
    }

    void Update()
    {
        Move();
    }

    private void PlatformMovement()
    {
        if(Random.Range(0, 2) == 0)
        {
            left = true;
        }
        else
        {
            left = false;
        }
    }

    private void Move()
    {
        if (left)
        {
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;
            transform.position = temp;

            if(transform.position.x < leftBound)
            {
                left = false;
            }
        }
        else
        {
            Vector3 temp = transform.position;
            temp.x += speed * Time.deltaTime;
            transform.position = temp;

            if (transform.position.x > rightBound)
            {
                left = true;
            }
        }
    }
}
