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
    public CheckpointManager checkpointManager;
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
            if (checkpointManager.curCheckpoint == checkpointManager.initialCheckpoint)
            {
                ResetGame();
            }
            else
            {
                checkpointManager.RespawnPlayer();
            }
        }
    }

    void ResetGame()
    {
        Debug.Log("Resetting");
        checkpointManager.ResetCheckpoint();
        checkpointManager.RespawnPlayer();
        ResetInteractables();
        ResetScore();
    }

    void ResetInteractables()
    {
        RecursiveInteractableCheck(interactableHolder);
    }

    private void RecursiveInteractableCheck(GameObject parent)
    {
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            GameObject child = parent.transform.GetChild(i).gameObject;
            Interactable interactable = child.GetComponent<Interactable>();
            if (interactable != null)
            {
                interactable.Enable();
            }
            else
            {
                RecursiveInteractableCheck(child);
            }
        }
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
