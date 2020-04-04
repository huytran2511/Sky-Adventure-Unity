using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollector : MonoBehaviour
{
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Platform")
        {
            collision.gameObject.SetActive(false);
        }

        if(collision.tag == "Player")
        {
            Time.timeScale = 0f;
        }
    }

}
