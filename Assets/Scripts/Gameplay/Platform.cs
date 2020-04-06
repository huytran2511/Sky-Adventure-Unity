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
        PlatformSetting();
    }

    void Update()
    {
        Move();
    }

    private void PlatformSetting()
    {
        if (Random.Range(0, 2) == 0)
        {
            left = true;
        }
        else
        {
            left = false;
        }
        if(Player.score == 2)
            gameObject.transform.localScale = new Vector3(0.7f, 1, 1);
        if (Player.score == 4)
            gameObject.transform.localScale = new Vector3(0.4f, 1, 1);

        //switch(Random.Range(0, 6))
        //{
        //    case 0:
        //        left = true;
        //        speed = 1f;
        //        gameObject.transform.localScale = new Vector3(0.4f, 1, 1);
        //        break;
        //    case 1:
        //        left = true;
        //        speed = 2f;
        //        gameObject.transform.localScale = new Vector3(0.4f, 1, 1);
        //        break;
        //    case 2:
        //        left = true;
        //        speed = 3f;
        //        gameObject.transform.localScale = new Vector3(0.4f, 1, 1);
        //        break;
        //    case 3:
        //        left = false;
        //        speed = 1f;
        //        gameObject.transform.localScale = new Vector3(0.4f, 1, 1);
        //        break;
        //    case 4:
        //        left = false;
        //        speed = 2f;
        //        gameObject.transform.localScale = new Vector3(0.4f, 1, 1);
        //        break;
        //    case 5:
        //        left = false;
        //        speed = 3f;
        //        gameObject.transform.localScale = new Vector3(0.4f, 1, 1);
        //        break;

        //}
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
