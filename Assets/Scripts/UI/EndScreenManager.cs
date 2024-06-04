using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreenManager : MonoBehaviour
{
    [SerializeField] private GameObject endScreen;
    [SerializeField] private Text highscoreText;
    [SerializeField] private GameObject highscoreIndicator;

    [SerializeField] private string highscorePrefix = "Highscore: ";

    public void ShowEndScreen(bool isHighscore)
    {
        highscoreText.text = highscorePrefix + HighscoreManager.highscore.ToString();
        highscoreIndicator.SetActive(isHighscore);
        endScreen.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
