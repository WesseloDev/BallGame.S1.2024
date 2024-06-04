using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighscoreManager : MonoBehaviour
{
    public static int highscore;
    private string highscoreKey = "Highscore";

    void Start()
    {
        highscore = GetSavedHighscore();
    }

    public bool SetHighscore(int newScore)
    {
        if (newScore > highscore)
        {
            highscore = newScore;
            SetSavedHighscore();

            return true;
        }

        Debug.Log("highscore: " + highscore.ToString());

        return false;
    }

    private int GetSavedHighscore()
    {
        return PlayerPrefs.HasKey(highscoreKey) ? PlayerPrefs.GetInt(highscoreKey) : 0;
    }

    private void SetSavedHighscore()
    {
        PlayerPrefs.SetInt(highscoreKey, highscore);
    }
}
