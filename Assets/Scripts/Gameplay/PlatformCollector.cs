using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollector : MonoBehaviour
{
    private GameObject panel;
    private AudioSource gameOver;
    
    void Awake()
    {
        panel = GameObject.Find("GameOver");
        panel.SetActive(false);
    }

    void Start()
    {
        gameOver = GetComponent<AudioSource>();
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
            panel.SetActive(true);
            gameOver.Play();
        }
    }

}
