using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public GameObject pauseScreen;
    public static bool gameIsPaused = false;
    public GameObject player;
    public GameObject gameOver;
    public GameObject winScreen;
    public bool finished;
    public AudioSource audioSrc;
    private GameObject life;

    private void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //IF YOU WIN
        if (finished == true)
        {
            life = GameObject.FindGameObjectWithTag("Life");
            life.GetComponent<Life>().Copy();
            Cursor.visible = true;
            winScreen.SetActive(true);
            audioSrc.Stop();


        }

        //IF YOU LOSE
        if (player == null) 
        {
            Cursor.visible = true;
            audioSrc.Stop();
            gameOver.SetActive(true); 
        }

        //PAUSE MENU
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (gameIsPaused == true)
            {
                Cursor.visible = false;
                Resume();
            }
            else 
            {
                Cursor.visible = true;
                
                Pause();
            }
           
        }
    }

    public void Resume() 
    {
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
        audioSrc.Play();
        gameIsPaused = false;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        pauseScreen.SetActive(true);
        audioSrc.Pause();
        gameIsPaused = true;
    }
}
