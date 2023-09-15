using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    Enemy enemy;
    [SerializeField] TextMeshProUGUI scoreTxt;
    public float currentScore;

    void Start()
    {
        currentScore = 0;
        scoreTxt.text = "Score: " + currentScore;
    }

    void LateUpdate()
    {
        scoreTxt.text = "Score: " + currentScore;
    }
    public void SetScore() { 
        currentScore += 1;
    }
}
