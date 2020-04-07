using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollector : MonoBehaviour
{
    private GameObject gameOverMenuUI;
    private AudioSource gameOverSound;
    
    void Awake()
    {
        gameOverMenuUI = GameObject.Find("GameOver");
        gameOverMenuUI.SetActive(false);
    }

    void Start()
    {
        gameOverSound = GetComponent<AudioSource>();
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
            gameOverMenuUI.SetActive(true);
            gameOverSound.Play();
        }
    }

}
