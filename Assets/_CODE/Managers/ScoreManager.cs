using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : Singleton<ScoreManager>
{
    public TextInterface ScoreInterface;
    public TextInterface GameOverScoreInterface;
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
