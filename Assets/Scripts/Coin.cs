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

    protected override void ShowVisuals()
    {
        coinRenderer.enabled = true;
        hoverScript.enabled = true;
        rotationScript.enabled = true;
    }

    protected override void HideVisuals()
    {
        coinRenderer.enabled = false;
        hoverScript.enabled = false;
        rotationScript.enabled = false;
    }
}
