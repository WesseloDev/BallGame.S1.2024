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

        float minutes = Mathf.FloorToInt(GameManager.timer / 60);
        float seconds = Mathf.FloorToInt(GameManager.timer % 60);

        timerText.text = timerPrefix + string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
