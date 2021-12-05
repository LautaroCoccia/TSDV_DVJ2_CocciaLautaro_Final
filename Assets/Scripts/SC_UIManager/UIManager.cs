using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject background; 
    [SerializeField] GameObject pauseMenu; 
    [SerializeField] GameObject credits; 
    [SerializeField] GameObject returnMenu; 
    [SerializeField] GameObject confirmMenu;

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

    void UpdatePause()
    {
        Debug.Log("HOLA");
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
        else if(confirmMenu.activeSelf)
        {
            returnMenu.SetActive(true);
            confirmMenu.SetActive(false);
        }
    }
    
}
