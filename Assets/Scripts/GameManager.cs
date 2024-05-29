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
    public Transform player;

    void Start()
    {
        gm = this;
        scoreTextManager = GetComponent<ScoreTextManager>();
        scoreTextManager.UpdateScoreText(score);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            ResetGame();
        }
    }

    void FixedUpdate()
    {
        if (player.position.y < -5f)
        {
            ResetGame();
        }
    }

    void ResetGame()
    {
        Debug.Log("Resetting");
        /*checkpointManager.ResetCheckpoint();
        checkpointManager.RespawnPlayer();
        ResetInteractables();*/
        ResetScore();
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreTextManager.UpdateScoreText(score);
        scoreTextManager.SpawnScorePopup(amount);
        //Debug.Log(score);
    }

    void ResetScore()
    {
        score = 0;
        scoreTextManager.UpdateScoreText(score);
    }

}
