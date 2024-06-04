using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public int score = 0;
    [SerializeField] private GameObject interactableHolder;
    private ScoreTextManager scoreTextManager;
    private HighscoreManager highscoreManager;
    private EndScreenManager endScreenManager;
    public Transform player;

    [SerializeField] private float initialTime;
    public static float timer;

    public static bool gameOver = false;

    void Start()
    {
        gm = this;
        scoreTextManager = GetComponent<ScoreTextManager>();
        scoreTextManager.UpdateScoreText(score);
        highscoreManager = GetComponent<HighscoreManager>();
        endScreenManager = GetComponent<EndScreenManager>();

        StartGame();
    }

    void Update()
    {
        if (gameOver) return;

        timer -= Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.R) || player.position.y < -5f || timer <= 0f)
        {
            EndGame();
            return;
        }
    }

    void EndGame()
    {
        Debug.Log("Ending game");
        gameOver = true;
        CursorManager.UnlockCursor();
        bool newHighscore = highscoreManager.SetHighscore(score);
        endScreenManager.ShowEndScreen(newHighscore);
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreTextManager.UpdateScoreText(score);
        scoreTextManager.SpawnScorePopup(amount);
        //Debug.Log(score);
    }

    public void AddTime(float amount)
    {

    }

    public void StartGame()
    {
        gameOver = false;
        timer = initialTime;
        CursorManager.LockCursor();
    }

    void ResetScore()
    {
        score = 0;
        scoreTextManager.UpdateScoreText(score);
    }
}
