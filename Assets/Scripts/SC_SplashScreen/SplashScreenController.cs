using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SplashScreenController : MonoBehaviour
{
    [SerializeField] Image companyLogoImage;
    [SerializeField] Image gameLogoImage;
    [SerializeField] TextMeshProUGUI startText;
    [SerializeField] Animator splashAnimator;

    public static Action<string> OnLoadNextLevel;
    bool canStart = false;
    float time;

    Color textColor;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fade());
        textColor = startText.color;
    }

    // Update is called once per frame
    void Update()
    {
        if(canStart)
        {
            if(Input.anyKey)
            {
                splashAnimator.SetBool("AnyKeyPressed", true);
                canStart = false;
                OnLoadNextLevel?.Invoke("MainMenu");
            }
            

        }
    }
    IEnumerator Fade()
    {
        Color color = companyLogoImage.color;
        while(time<2)
        {
            time += Time.deltaTime;
            color.a = Mathf.Lerp(0 , 1, time);
            companyLogoImage.color = color;
            yield return null;
        }
        yield return new WaitForSeconds(1);
        time = 0;
        while (time < 2)
        {
            time += Time.deltaTime;
            color.a = Mathf.Lerp(1 , 0, time);
            companyLogoImage.color = color;
            yield return null;
        }
        yield return new WaitForSeconds(0.25f);
        time = 0;
        while (time < 2)
        {
            time += Time.deltaTime;
            color.a = Mathf.Lerp(0 , 1, time);
            gameLogoImage.color = color;
            yield return null;
        }
        time = 0;
        canStart = true;
        splashAnimator.SetTrigger("StartFade");
    } 
}
