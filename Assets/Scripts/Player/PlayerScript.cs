using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D playerBody;
    private Button jumpButton;
    
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
        
    }
    public void Jump()
    {
        if(playerBody.velocity.y == 0)
        {
            playerBody.velocity = new Vector2(0, 10);
        }
    }
}
