using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private bool canMove;
    private float distance = 6.475f;
    private float newDestination;

    void OnEnable()
    {
        Player.move += Move;
    }

    void OnDisable()
    {
        Player.move -= Move;
    }

    void Update()
    {
        MoveCamera();
    }

    private void MoveCamera()
    {
        if (canMove)
        {
            Vector3 temp = transform.position;
            temp.y += 3f * Time.deltaTime;
            transform.position = temp;

            if(transform.position.y >= newDestination)
            {
                canMove = false;
            }
        }
    }
    
    void Move()
    {
        newDestination = transform.position.y + distance;
        canMove = true;
    }
}
