using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager> 
{
    public UnityEvent OnGameOver = new UnityEvent();
    public Character Player;   

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            RestartGame();
    }

    void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void FinishGame()
    {
        OnGameOver.Invoke();
    }
}
