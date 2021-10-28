using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager ins;
    public static bool GameIsPause;
    public GameObject PauseMenuUI;
    public GameObject SettingMenuUI;
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
        Debug.Log("Win");
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
        Debug.Log("Load Menu");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
