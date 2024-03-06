using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private BoxCollider boxCollider;
    [SerializeField] private bool disabled = false;

    private void OnTriggerEnter(Collider other)
    {
        if (disabled) return;

        CheckpointManager checkpointManager = other.gameObject.GetComponent<CheckpointManager>();
        if (checkpointManager != null)
        {
            checkpointManager.SetCheckpoint(transform.position);
            disabled = true;
        }
    }
}
