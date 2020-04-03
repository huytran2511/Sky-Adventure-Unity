using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private float leftBound = -2.89f, rightBound = 2.89f;
    private float speed = 1f;
    private bool left;
    // Start is called before the first frame update
    void Awake()
    {
        PlatformMovement();
    }

    // Update is called once per frame
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
