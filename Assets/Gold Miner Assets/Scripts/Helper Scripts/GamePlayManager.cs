using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GamePlayManager : MonoBehaviour
{
    public static GamePlayManager instance;

    [SerializeField] private Text countDownText;
    private int countDownTime = 60;
    [SerializeField] private Text scoreText;
    private int scoreCount;
    [SerializeField] private Image scoreFillUi;
    void Awake()
    {
        if(instance == null){
            instance = this;
        }
    }

    void Start()
    {
        DisplayScore(0);
        countDownText.text = countDownTime.ToString();
        StartCoroutine("CountingDown");
    }

    IEnumerator CountingDown(){
        yield return new WaitForSeconds(1f);
        countDownTime--;
        countDownText.text = countDownTime.ToString();
        if(countDownTime <= 10){
           SoundManager.instance.TimeRunningOutSound(true); 
        }
        StartCoroutine("CountingDown");
        if(countDownTime <= 0){
            StopCoroutine("CountingDown");
            countDownText.text = "0";
            SoundManager.instance.TimeRunningOutSound(false);
            SoundManager.instance.GameOverSound();
            StartCoroutine("RestartGame");
        }
    }

    public void DisplayScore(int score){
        if(scoreText == null){
            return;
        }
        scoreCount += score;
        scoreText.text = "$" + scoreCount;
        scoreFillUi.fillAmount = (float)scoreCount / 100;
        if(scoreCount >= 100){
            SoundManager.instance.GameOverSound();
            StopCoroutine("CountingDown");
            countDownText.text = "100";
            StartCoroutine("RestartGame");
        }
    }   
    IEnumerator RestartGame(){
        yield return new WaitForSeconds(4f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("GamePlay");
    }

}
