using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerGui : MonoBehaviour
{
    [SerializeField] private Text timerText;
    [SerializeField] private string timerPrefix = "Time Left:\n";

    void Update()
    {
        if (GameManager.gameOver) return;

        timerText.text = timerPrefix + Mathf.FloorToInt(GameManager.timer).ToString();
    }
}
