using DiepMono.UI;
using DiepMono.Utils;
using UnityEngine;
using UnityEngine.Events;

namespace DiepMono.Managers
{
    public class ScoreManager : Singleton<ScoreManager>
    {
        public TextUI ScoreInterface;
        public TextUI GameOverScoreInterface;
        int score = 0;
        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
            }
        }

        [HideInInspector] public UnityEvent OnScore = new UnityEvent();

        public void GainScore(int newScore)
        {
            Score += newScore;
            ScoreInterface.UpdateInterface(Score);
            GameOverScoreInterface.UpdateInterface(Score);
            OnScore.Invoke();
        }

    } 
}
