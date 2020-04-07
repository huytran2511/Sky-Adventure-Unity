using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Platform : MonoBehaviour
{
    private float BOUND_S = 3.36f, BOUND_M = 2.89f, BOUND_L = 2.43f;
    //private float MEDIUM = 2f, FAST = 3f, XTFAST = 4f, XXTFAST = 5f;
    
    private float leftBound = 0f, rightBound = 0f; //
    
    private float speed = 1f; // slow
    private static float speedChange = 0f;

    private bool left;
    
    void Awake()
    {
        PlatformSetting();
    }

     void Update()
    {
        MovePlatform();
    }

    private void PlatformSetting()
    {
        //if (Player.score >= 3)
        //    speed = MEDIUM;
        //if (Player.score >= 6)
        //    speed = FAST;
        //if (Player.score >= 9)
        //    speed = XTFAST;
        //if (Player.score >= 12)
        //    speed = XXTFAST;

        //if (Player.score == 0)
        //    speed = 1f;
        if(Player.score == 0)
        {
            speedChange = 0f;
        }
        if(Player.score > 0)
        {
            if(Player.score % 3 == 0)
            {
                speedChange += 0.5f;
            }
            speed += speedChange;
        }

        switch(Random.Range(0, 2))
        {
            case 0:
                left = true;
                leftBound = -BOUND_L;
                rightBound = BOUND_L;
                break;
            case 1:
                left = false;
                leftBound = -BOUND_L;
                rightBound = BOUND_L;
                break;
        }

        //switch (Random.Range(0, 6))
        //{
        //    case 0:
        //        left = true;
        //        gameObject.transform.localScale = new Vector3(0.4f, 1, 1);
        //        leftBound = -BOUND_S;
        //        rightBound = BOUND_S;
        //        break;
        //    case 1:
        //        left = true;
        //        gameObject.transform.localScale = new Vector3(0.7f, 1, 1);
        //        leftBound = -BOUND_M;
        //        rightBound = BOUND_M;
        //        break;
        //    case 2:
        //        left = true;
        //        gameObject.transform.localScale = new Vector3(1, 1, 1);
        //        leftBound = -BOUND_L;
        //        rightBound = BOUND_L;
        //        break;
        //    case 3:
        //        left = false;
        //        gameObject.transform.localScale = new Vector3(0.4f, 1, 1);
        //        leftBound = -BOUND_S;
        //        rightBound = BOUND_S;
        //        break;
        //    case 4:
        //        left = false;
        //        gameObject.transform.localScale = new Vector3(0.7f, 1, 1);
        //        leftBound = -BOUND_M;
        //        rightBound = BOUND_M;
        //        break;
        //    case 5:
        //        left = false;
        //        gameObject.transform.localScale = new Vector3(1, 1, 1);
        //        leftBound = -BOUND_L;
        //        rightBound = BOUND_L;
        //        break;
        //}

        if (SceneManager.GetActiveScene().name == "Lv1")
        {
            if (Player.score == 5)
            {
                gameObject.transform.localScale = new Vector3(2.56f, 1, 1);
                speed = 0f;

                gameObject.transform.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
            }
        }

        if (SceneManager.GetActiveScene().name == "Lv2")
        {
            if (Player.score == 5)
            {
                gameObject.transform.localScale = new Vector3(2.56f, 1, 1);
                speed = 0f;

                gameObject.transform.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
            }
        }

        if (SceneManager.GetActiveScene().name == "Lv3") 
        {
            if (Player.score == 15)
            {
                gameObject.transform.localScale = new Vector3(2.56f, 1, 1);
                speed = 0f;

                gameObject.transform.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
            }
        }
    }

    private void MovePlatform()
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
