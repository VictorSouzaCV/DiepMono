using DiepMono.Characters;
using DiepMono.Utils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace DiepMono.Managers
{
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
}
