﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private float BOUND_S = 3.36f, BOUND_M = 2.89f, BOUND_L = 2.43f;
    private float MEDIUM = 2f, FAST = 3f, XTFAST = 4f;
    
    //private float leftBound = -3.36f, rightBound = 3.36f; // S size 0.4
    //private float leftBound = -2.89f, rightBound = 2.89f; // M size 0.7
    private float leftBound = -2.43f, rightBound = 2.43f; // L size 1
    
    //private float speed = 1f; // slow
    //private float speed = 2f; // medium
    private float speed = 1f; // fast

    private bool left;
    
    void Awake()
    {
        PlatformSetting();
    }

    void Update()
    {
        Move();
    }

    private void PlatformSetting()
    {
        //if (Random.Range(0, 2) == 0)
        //{
        //    left = true;
        //}
        //else
        //{
        //    left = false;
        //}
        if (Player.score >= 5)
            speed = MEDIUM;
        if (Player.score >= 10)
            speed = FAST;
        if (Player.score >= 15)
            speed = XTFAST;

        switch (Random.Range(0, 6))
        {
            case 0:
                left = true;
                gameObject.transform.localScale = new Vector3(0.4f, 1, 1);
                leftBound = -BOUND_S;
                rightBound = BOUND_S;
                break;
            case 1:
                left = true;
                gameObject.transform.localScale = new Vector3(0.7f, 1, 1);
                leftBound = -BOUND_M;
                rightBound = BOUND_M;
                break;
            case 2:
                left = true;
                gameObject.transform.localScale = new Vector3(1, 1, 1);
                leftBound = -BOUND_L;
                rightBound = BOUND_L;
                break;
            case 3:
                left = false;
                gameObject.transform.localScale = new Vector3(0.4f, 1, 1);
                leftBound = -BOUND_S;
                rightBound = BOUND_S;
                break;
            case 4:
                left = false;
                gameObject.transform.localScale = new Vector3(0.7f, 1, 1);
                leftBound = -BOUND_M;
                rightBound = BOUND_M;
                break;
            case 5:
                left = false;
                gameObject.transform.localScale = new Vector3(1, 1, 1);
                leftBound = -BOUND_L;
                rightBound = BOUND_L;
                break;

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
