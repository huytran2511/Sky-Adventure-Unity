using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D playerBody;
    private Button jumpButton;
    private bool hasJumped;
    private GameObject parent;
        
    // Start is called before the first frame update
    void Awake()
    {
        jumpButton = GameObject.Find("JumpButton").GetComponent<Button>();
        jumpButton.onClick.AddListener(() => Jump());

        playerBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hasJumped && playerBody.velocity.y == 0)
        {
            hasJumped = false;
            transform.SetParent(parent.transform);
        }
        else if(parent != null)
        {
            transform.SetParent(parent.transform);
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
        
    }
    void OnTriggerExit2D(Collider2D collision)
    {

    }


}
