using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager ins;
    public static bool GameIsPause;
    public static bool GameIsOver;
    public GameObject PauseMenuUI;
    public GameObject SettingMenuUI;
    public GameObject GameOverUI;
    public GameObject GameWinUI;
    // Start is called before the first frame update
    void Start()
    {
        Ins();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameWin()
    {
        
        GameWinUI.SetActive(true);

    }
    void Ins()
    {
        if (ins == null)
        {
            ins = this;
        }
    }
   public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }
    public void Setting()
    {
        SettingMenuUI.SetActive(true);
    }
    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void ShowGameOver()
    {
        Time.timeScale = 0f;
        GameIsOver = true;
        GameOverUI.SetActive(true);

    }
    public void Replay()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
