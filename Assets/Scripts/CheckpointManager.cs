using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private Vector3 initialCheckpoint;
    private Vector3 curCheckpoint;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Rigidbody rb;

    void Start()
    {
        initialCheckpoint = playerTransform.position;
        curCheckpoint = initialCheckpoint;
    }

    void FixedUpdate()
    {
        if (playerTransform.position.y < -5f)
        {
            RespawnPlayer();
        }
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
        rb.velocity = Vector3.zero;
    }
}
