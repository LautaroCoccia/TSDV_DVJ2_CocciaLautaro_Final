using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    
    [SerializeField] int lives = 3;
    [SerializeField] int targets = 3;

    private void OnEnable() 
    {
        VehicleController.OnHitPlayer += UpdateLives;
    }
    private void OnDisable() 
    {
        VehicleController.OnHitPlayer -= UpdateLives;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void UpdateLives()
    {
        lives--;
        //ResetPlayerPos;
        if(lives <= 0)
        {
            Debug.Log("Perdiste");
        }

    }
}