using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public Vector3 initialCheckpoint;
    public Vector3 curCheckpoint;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Rigidbody playerRb;

    void Start()
    {
        initialCheckpoint = playerTransform.position;
        curCheckpoint = initialCheckpoint;
    }

    public void SetCheckpoint(Vector3 newCheckpoint)
    {
        Debug.Log("Set new checkpoint");
        curCheckpoint = newCheckpoint;
    }

    public void ResetCheckpoint()
    {
        curCheckpoint = initialCheckpoint;
    }

    public void RespawnPlayer()
    {
        Debug.Log("teleporting to checkpoint");
        playerTransform.position = curCheckpoint;
        playerRb.velocity = Vector3.zero;
    }
}