using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealth : MonoBehaviour
{
    [SerializeField] Text healthText = null;
    [Range(1,100)]
    [SerializeField] int baseHealth = 10;

    int score = 0;
    Text scoreUI = null;

    private void Awake()
    {
        scoreUI = GameObject.Find("ScoreText").GetComponent<Text>();
    }

    private void Start()
    {
        scoreUI.text = score.ToString();
        UpadteHealthText();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other)
        {
            baseHealth--;
            UpadteHealthText();
        }
    }

    private void UpadteHealthText()
    {
        healthText.text = baseHealth.ToString();
    }

    public void UpdateScoreText(int scoreIncrese)
    {
        score += scoreIncrese;
        scoreUI.text = score.ToString("### ###");
    }

}
