using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LordSceneManager : MonoBehaviour
{
    //[SerializeField] Animator transition;
    private void OnEnable() 
    {
        SplashScreenController.OnLoadNextLevel += LoadScene;
    }
    private void OnDisable() 
    {
        SplashScreenController.OnLoadNextLevel -= LoadScene;
    }
    [SerializeField] float transitionTime = 1f;
    void StartTransition()
    {
        //transition.SetTrigger("Start");
    }
    public void LoadScene(string levelName)
    {
        StartCoroutine(LoadSceneCR(levelName));
    }
    IEnumerator LoadSceneCR(string levelName)
    {
        Time.timeScale = 1;

        StartTransition();

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelName);
    }
}
