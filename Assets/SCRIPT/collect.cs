using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Security.Cryptography;

public class collect: MonoBehaviour
{
  

    private TextMeshProUGUI ScoreText;
    private TextMeshProUGUI ScoreText1;
    private TextMeshProUGUI ScoreText2;
    private int Score1 = 0;
    private int Score2 = 0;
    private int Score3 = 0;
    [SerializeField] GameObject obstacl1;
    [SerializeField] GameObject obstacl2;
    [SerializeField] private AudioClip Coins;


    public int maxscore=5;

   
    void Awake()
    {
        ScoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        ScoreText1 = GameObject.Find("ScoreText1").GetComponent<TextMeshProUGUI>();
        ScoreText2 = GameObject.Find("ScoreText2").GetComponent<TextMeshProUGUI>();
        ScoreText.text = "0";
        ScoreText1.text = "0";
        ScoreText2.text = "0";

    }

    private void OnTriggerEnter2D(Collider2D target)
    {

        Debug.Log("Trigger entered");
        if (target.CompareTag("green"))
        {
            
           SoundManger.Instance.PlaySound(Coins);
            Debug.Log("Green coin");
            target.gameObject.SetActive(false);
            Score1++;
            ScoreText.text = Score1.ToString();
            DestroyObejct();
            CheckWinCondition();
        }
        else if (target.CompareTag("red"))
        {
            SoundManger.Instance.PlaySound(Coins);
            Debug.Log("red Coin");
            target.gameObject.SetActive(false);
            Score2++;
            ScoreText1.text = Score2.ToString();
            DestroyObejct();
            CheckWinCondition();
        }
        else if (target.CompareTag("blue"))
        {
            SoundManger.Instance.PlaySound(Coins);
            Debug.Log("blue coin");
            target.gameObject.SetActive(false);
            Score3++;
            ScoreText2.text = Score3.ToString();
            
            CheckWinCondition();
        }
    }
    private void DestroyObejct()
    {
        if (Score1 >= 3 && Score2 >= 3 )
        {
         obstacl1.SetActive(false);
           obstacl2.SetActive(false);

        }
    }

    private void CheckWinCondition()
    {
        if (Score1 >= maxscore && Score2 >= maxscore && Score3 >= maxscore)
        {
           
            Debug.Log("Player wins!");
            SceneManager.LoadScene("WinScene");



        }
    }
}