using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] int score = 0;
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
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void UpdateScore(int newScore)
    {
        score += newScore;
    }
}