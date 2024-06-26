using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Interactable
{
    [SerializeField] private MeshRenderer coinRenderer;

    public int value = 1;

    protected override void Interact()
    {
        GameManager.AddScore(value);
        base.Interact();
    }
}
