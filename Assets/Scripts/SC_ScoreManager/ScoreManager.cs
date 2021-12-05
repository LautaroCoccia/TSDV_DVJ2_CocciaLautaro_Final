using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ScoreManager : MonoBehaviourSingleton<ScoreManager>
{
    [SerializeField] int score = 0;

    public static Action<int> OnUpdateScore;
    private void OnEnable() 
    {
        BoxCollisionManager.OnPlayerGoal += UpdateScore;
    }
    private void OnDisable() 
    {
        BoxCollisionManager.OnPlayerGoal += UpdateScore;
    }
    // Start is called before the first frame update
    void Start()
    {
        OnUpdateScore?.Invoke(score);
    }
    void UpdateScore(int newScore)
    {
        score += newScore;
        OnUpdateScore?.Invoke(score);
    }
    public void ResetScore()
    {
        score = 0;
    }
}