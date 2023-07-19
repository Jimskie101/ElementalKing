using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject main;
    public GameObject stages;
    public GameObject tutorial;
    public GameObject credits;
    public GameObject life;
    private void Start()
    {
        life = GameObject.FindGameObjectWithTag("Life");
    }

    public void Exit() { Application.Quit(); }
    public void Stages() { stages.SetActive(true); main.SetActive(false) ; }
    public void Back() { main.SetActive(true); stages.SetActive(false); tutorial.SetActive(false); credits.SetActive(false); }
    public void MainMenu() { SceneManager.LoadScene(0); }
    public void Restart() { life.GetComponent<Life>().LifeReset();  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); Time.timeScale = 1f; }
    public void Play() { tutorial.SetActive(true); main.SetActive(false); }
    public void Credits() { credits.SetActive(true); main.SetActive(false); }
    public void Tutorial() { SceneManager.LoadScene(1); }
    public void Stage1() { life.GetComponent<Life>().LifeReset(); SceneManager.LoadScene(2); Time.timeScale = 1f; }
    public void Stage2() { SceneManager.LoadScene(3); Time.timeScale = 1f; }
    public void Stage3() { SceneManager.LoadScene(4); Time.timeScale = 1f; }

}
