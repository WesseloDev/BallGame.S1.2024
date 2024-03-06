using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private Vector3 curCheckpoint;
    private Transform playerTransform;
    private Rigidbody rb;

    void Start()
    {
        playerTransform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        curCheckpoint = playerTransform.position;
    }

    void FixedUpdate()
    {
        if (playerTransform.position.y < -5f)
        {
            Debug.Log("teleporting to checkpoint");
            playerTransform.position = curCheckpoint;
            rb.velocity = Vector3.zero;
        }
    }

    public void SetCheckpoint(Vector3 newCheckpoint)
    {
        Debug.Log("Set new checkpoint");
        curCheckpoint = newCheckpoint;
    }
}
