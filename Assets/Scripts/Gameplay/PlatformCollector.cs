using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollector : MonoBehaviour
{
    private GameObject gameOverMenuUI;
    public static bool gameOver = false;
    private AudioSource gameOverSound;
    
    void Awake()
    {
        gameOverMenuUI = GameObject.Find("GameOver");
        gameOverMenuUI.SetActive(false);
        gameOver = false;
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
            gameOver = false;
        }

        if(collision.tag == "Player")
        {
            Time.timeScale = 0f;
            gameOverMenuUI.SetActive(true);
            gameOver = true;
            gameOverSound.Play();
        }
    }

}
