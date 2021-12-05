using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    [Header("Ingame HUD")]
    [SerializeField] TextMeshProUGUI timeText; 
    [SerializeField] TextMeshProUGUI livesText; 
    [SerializeField] TextMeshProUGUI boxesText;
    [SerializeField] TextMeshProUGUI scoreText;

    [Header("Final screen Stats")]
    [SerializeField] TextMeshProUGUI finalTimeText; 
    [SerializeField] TextMeshProUGUI finalLivesText; 
    [SerializeField] TextMeshProUGUI finalBoxesText;
    [SerializeField] TextMeshProUGUI finalScoreText;
    [SerializeField] GameObject finalStats; 

    
    [Header("UI Objects")]
    [SerializeField] GameObject startLevel; 
    [SerializeField] GameObject background; 
    [SerializeField] GameObject pauseMenu; 
    [SerializeField] GameObject credits; 
    [SerializeField] GameObject returnMenu; 
    [SerializeField] GameObject loseScreen; 
    [SerializeField] GameObject winScreen; 
    private void OnEnable() 
    {
        LevelManager.OnSetPause += UpdatePause;
        LevelManager.OnUpdateTime += UIUpdateTime;
        LevelManager.OnUpdateBoxes += UIUpdateBoxes;
        LevelManager.OnUpdateLives += UIUpdateLives;
        LevelManager.OnStartLevel += UIUpdateStart;
        ScoreManager.OnUpdateScore += UIUpdateScore;
    }
    private void OnDisable() 
    {
        ScoreManager.OnUpdateScore -= UIUpdateScore;
        LevelManager.OnStartLevel -= UIUpdateStart;
        LevelManager.OnUpdateLives -= UIUpdateLives;
        LevelManager.OnUpdateBoxes -= UIUpdateBoxes;
        LevelManager.OnUpdateTime -= UIUpdateTime;
        LevelManager.OnSetPause -= UpdatePause;
    }

    //QUE ASCO. Buscar una mejor manera de hacer esto 
    //Activa/Desactiva pantallas hasta que sale de la pausa etc
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
            finalTimeText.text = timeText.text;
            if(returnMenu.activeSelf)
            {
                loseScreen.SetActive(true);
                finalStats.SetActive(true);
                returnMenu.SetActive(false);
            }
            else if(!loseScreen.activeSelf)
            {
                Time.timeScale = 0;
                background.SetActive(true);
                finalStats.SetActive(true);
                loseScreen.SetActive(true);
            }
            else if(loseScreen.activeSelf)
            {
                loseScreen.SetActive(false);
                finalStats.SetActive(false);
                returnMenu.SetActive(true);
            }
        }
        else if(LevelManager.gameState.win == actualState)
        {
            finalTimeText.text = timeText.text;
            if(returnMenu.activeSelf)
            {
                winScreen.SetActive(true);
                finalStats.SetActive(true);
                returnMenu.SetActive(false);
            }
            else if(!winScreen.activeSelf)
            {
                Time.timeScale = 0;
                background.SetActive(true);
                finalStats.SetActive(true);
                winScreen.SetActive(true);
            }
            else if(winScreen.activeSelf)
            {
                Debug.Log("HOAL");
                winScreen.SetActive(false);
                finalStats.SetActive(false);
                returnMenu.SetActive(true);
            }
        }
    }
    
    void UIUpdateTime(int minutes, int seconds)
    {
        timeText.text = minutes.ToString() + ":" + seconds.ToString();
    }
    void UIUpdateBoxes(int boxCount, int maxBoxes)
    {
        boxesText.text = boxCount.ToString() + " / " + maxBoxes.ToString();
        finalBoxesText.text = boxesText.text ;
    }
    void UIUpdateLives(int lives)
    {
        livesText.text = lives.ToString();
        finalLivesText.text = livesText.text;
    }
    void UIUpdateScore(int score)
    {
        scoreText.text = score.ToString();
        finalScoreText.text = scoreText.text;
    }

    void UIUpdateStart()
    {
        startLevel.SetActive(false);
        background.SetActive(false);
    }
}
