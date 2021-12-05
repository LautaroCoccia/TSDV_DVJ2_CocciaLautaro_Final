using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelManager : MonoBehaviour
{
    
    [SerializeField] int lives = 3;
    [SerializeField] int maxBoxes = 5;
    [SerializeField] int boxesCount = 0;

    public enum gameState
    {
        win,
        lose,
        playOrPause
    }
    gameState actualState;
    public static Action<gameState> OnSetPause; 
    //bool isPaused = false;
    private void OnEnable() 
    {
        BoxCollisionManager.OnPlayerGoal += UpdateBoxes;
        VehicleController.OnHitPlayer += UpdateLives;
    }
    private void OnDisable() 
    {
        BoxCollisionManager.OnPlayerGoal -= UpdateBoxes;
        VehicleController.OnHitPlayer -= UpdateLives;
    }
    // Start is called before the first frame update
    void Start()
    {
        actualState = gameState.playOrPause;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            UpdatePause();
        }
    }
    void UpdateLives()
    {
        lives--;
        if(lives <= 0)
        {
            actualState = gameState.lose;
            OnSetPause?.Invoke(actualState);
        }
    }
    void UpdateBoxes(int nonUse)
    {
        boxesCount++;
        if(boxesCount >= maxBoxes)
        {
            actualState = gameState.win;
            OnSetPause?.Invoke(actualState);
        }
    }   
    public void UpdatePause()
    {
        //isPaused = !isPaused;
        
        OnSetPause?.Invoke(actualState);
    }
}