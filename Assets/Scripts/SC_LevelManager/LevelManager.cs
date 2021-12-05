using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelManager : MonoBehaviour
{
    
    [SerializeField] int lives = 3;
    [SerializeField] int maxBoxes = 5;
    [SerializeField] int boxesCount = 0;

    public static Action OnSetPause; 
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
            Debug.Log("Perdiste");
        }
    }
    void UpdateBoxes(int nonUse)
    {
        boxesCount++;
        if(boxesCount >= maxBoxes)
        {
            Debug.Log("Ganaste");
        }
    }   
    public void UpdatePause()
    {
        //isPaused = !isPaused;
        
        OnSetPause?.Invoke();
    }
}