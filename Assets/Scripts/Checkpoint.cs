using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : Interactable
{
    protected override void Interact()
    {
        GameManager.gm.checkpointManager.SetCheckpoint(transform.position);
        base.Interact();
    }
}
