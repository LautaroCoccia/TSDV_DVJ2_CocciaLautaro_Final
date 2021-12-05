using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject background; 
    [SerializeField] GameObject pauseMenu; 
    [SerializeField] GameObject credits; 
    [SerializeField] GameObject returnMenu; 
    [SerializeField] GameObject loseScreen; 
    [SerializeField] GameObject winScreen; 

    private void OnEnable() 
    {
        LevelManager.OnSetPause += UpdatePause;
    }
    private void OnDisable() 
    {
        LevelManager.OnSetPause -= UpdatePause;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void UpdatePause(LevelManager.gameState actualState)
    {
        if(LevelManager.gameState.playOrPause == actualState)
        {
            if(!background.activeSelf)
            {
                background.SetActive(true);
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
            else if(pauseMenu.activeSelf)
            {
                Debug.Log("Play");
                background.SetActive(false);
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
            }
            else if(credits.activeSelf)
            {
                pauseMenu.SetActive(true);
                credits.SetActive(false);
            }
            else if(returnMenu.activeSelf)
            {
                pauseMenu.SetActive(true);
                returnMenu.SetActive(false);
            }
        }
        else if(LevelManager.gameState.lose == actualState)
        {
            if(returnMenu.activeSelf)
            {
                loseScreen.SetActive(true);
                returnMenu.SetActive(false);
            }
            else if(!loseScreen.activeSelf)
            {
                Time.timeScale = 0;
                background.SetActive(true);
                loseScreen.SetActive(true);
            }
            else if(loseScreen.activeSelf)
            {
                loseScreen.SetActive(false);
                returnMenu.SetActive(true);
            }
        }
        else if(LevelManager.gameState.win == actualState)
        {
            if(returnMenu.activeSelf)
            {
                winScreen.SetActive(true);
                returnMenu.SetActive(false);
            }
            else if(!winScreen.activeSelf)
            {
                Time.timeScale = 0;
                background.SetActive(true);
                winScreen.SetActive(true);
            }
            else if(winScreen.activeSelf)
            {
                winScreen.SetActive(false);
                returnMenu.SetActive(true);
            }
        }
    }
    
}
