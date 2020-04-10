using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    private Rigidbody2D playerBody;
    private Button jumpButton;
    private bool hasJumped, platformBound;

    public delegate void MoveCamera();
    public static event MoveCamera move;

    private GameObject parent;
    public GameObject FinishMenuUI;
    public static bool finish = false;

    private TMP_Text scoreText;
    private TMP_Text highscore_GOText;
   
    public static int score = 0;
    public static int highscore = 0;

    public AudioSource[] sounds;
    public AudioSource jumpSound, landSound, winningSound;

    public static bool winLv1 = false, winLv2 = false;

    void Awake()
    {
        jumpButton = GameObject.Find("JumpButton").GetComponent<Button>();
        jumpButton.onClick.AddListener(() => Jump());
        
        playerBody = GetComponent<Rigidbody2D>();

        scoreText = GameObject.Find("Score").GetComponent<TMP_Text>();
        highscore_GOText = GameObject.Find("HighScore_GO").GetComponent<TMP_Text>();
        scoreText.text = score.ToString();

        if(SceneManager.GetActiveScene().name != "EndlessGameMode")
        {
            FinishMenuUI = GameObject.Find("FinishMenu");
            FinishMenuUI.SetActive(false);
            finish = false;
        }
    }

    void Start()
    {
        sounds = GetComponents<AudioSource>();
        jumpSound = sounds[0];
        landSound = sounds[1];
        if (SceneManager.GetActiveScene().name != "EndlessGameMode")
        {
            winningSound = sounds[2];
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            Jump();
        }

        if (hasJumped && playerBody.velocity.y == 0)
        {
            if(!platformBound)
            {
                hasJumped = false;

                score++;
                scoreText.text = score.ToString();

                if (SceneManager.GetActiveScene().name == "EndlessGameMode")
                {
                    if (score > highscore)
                    {
                        highscore = score;
                    }
                }
                
                highscore_GOText.text = "High Score: " + highscore.ToString();

                transform.SetParent(parent.transform);
                GameMechanics.instance.CreatePlatform();

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
            playerBody.velocity = new Vector2(0, 12);
            transform.SetParent(null);
            hasJumped = true;
            jumpSound.Play();
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            if(playerBody.velocity.y == 0)
            {
                landSound.Play();

                if (SceneManager.GetActiveScene().name == "Lv1")
                {
                    if (score == 5)
                    {
                        FinishMenuUI.SetActive(true);
                        finish = true;
                        Time.timeScale = 0f;
                        winningSound.Play();
                        winLv1 = true;
                    }
                }

                if (SceneManager.GetActiveScene().name == "Lv2")
                {
                    if (score == 10)
                    {
                        FinishMenuUI.SetActive(true);
                        finish = true;
                        Time.timeScale = 0f;
                        winningSound.Play();
                        winLv2 = true;
                    }
                }

                if (SceneManager.GetActiveScene().name == "Lv3")
                {
                    if (score == 15)
                    {
                        FinishMenuUI.SetActive(true);
                        finish = true;
                        Time.timeScale = 0f;
                        winningSound.Play();
                    }
                }
            }
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
