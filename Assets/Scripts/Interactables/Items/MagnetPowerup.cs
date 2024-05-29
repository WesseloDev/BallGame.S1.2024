using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetPowerup : Interactable
{
    [SerializeField] private float magnetTime;
    [SerializeField] private PlayerMovement player;

    protected override void Interact()
    {
        player.AddMagnetTime(magnetTime);
        base.Interact();
    }

}
