using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D playerBody;
    private Button jumpButton;
    private bool hasJumped, platformBound;

    public delegate void MoveCamera();
    public static event MoveCamera move;

    private GameObject parent;
    
    void Awake()
    {
        jumpButton = GameObject.Find("JumpButton").GetComponent<Button>();
        jumpButton.onClick.AddListener(() => Jump());

        playerBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(hasJumped && playerBody.velocity.y == 0)
        {
            if(!platformBound)
            {
                hasJumped = false;
                transform.SetParent(parent.transform);

                if(move != null)
                {
                    move();
                }
            } 
            else if (parent != null)
            {
                transform.SetParent(parent.transform);
            }
        }
    }
    public void Jump()
    {
        if(playerBody.velocity.y == 0)
        {
            playerBody.velocity = new Vector2(0, 10);
            hasJumped = true;
            //if (Input.GetKeyDown("space"))
            //{
            //    playerBody.velocity = new Vector2(0, 10);
            //}
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            parent = collision.gameObject;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            parent = null;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "MainCamera")
        {
            platformBound = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "MainCamera")
        {
            platformBound = false;
        }
    }


}
