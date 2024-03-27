using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private Collider itemCollider;

    private void Start()
    {
        itemCollider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") return;
        Interact();
    }

    protected virtual void Interact()
    {
        Disable();
    }

    public void Enable()
    {
        itemCollider.enabled = true;
        ShowVisuals();
    }

    private void Disable()
    {
        itemCollider.enabled = false;
        HideVisuals();

    }

    protected virtual void HideVisuals() { }

    protected virtual void ShowVisuals() { }
}
