using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Interactable
{
    [SerializeField] private MeshRenderer coinRenderer;
    [SerializeField] private Hover hoverScript;
    [SerializeField] private Rotation rotationScript;

    public int value = 1;

    protected override void Interact()
    {
        GameManager.gm.AddScore(value);
        base.Interact();
    }
}
