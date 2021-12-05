using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelManager : MonoBehaviour
{
    [SerializeField] int lives = 3;
    [SerializeField] int maxBoxes = 5;
    [SerializeField] int boxesCount = 0;

    int minutes;
    int seconds;
    float timer;

    public enum gameState
    {
        win,
        lose,
        playOrPause
    }
    gameState actualState;
    public static Action<gameState> OnSetPause; 
    public static Action<int,int> OnUpdateBoxes; 
    public static Action<int,int> OnUpdateTime;
    public static Action<int> OnUpdateLives; 
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
        OnUpdateBoxes?.Invoke(boxesCount,maxBoxes);
        OnUpdateLives?.Invoke(lives);
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            UpdatePause();
        }
        if(Time.timeScale > 0 && actualState != gameState.win || actualState != gameState.lose)
        {
            updateTime();
            OnUpdateTime?.Invoke(minutes,seconds);
        }
    }
    void UpdateLives()
    {
        lives--;
        OnUpdateLives?.Invoke(lives);
        if(lives <= 0)
        {
            actualState = gameState.lose;
            OnSetPause?.Invoke(actualState);
        }
    }
    void UpdateBoxes(int nonUse)
    {
        boxesCount++;
        OnUpdateBoxes?.Invoke(boxesCount,maxBoxes);
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

    void updateTime()
    {
        timer += Time.deltaTime;

        if(timer > 1)
        {
            seconds++;
            timer = 0;
        }
        if(seconds >59)
        {
            minutes++;
            seconds = 0;    
        }
    }
}