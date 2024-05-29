using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    [SerializeField] private float hoverSpeed;
    [SerializeField] private float hoverDistance;
    [SerializeField] private float offset;
    private float initialYPos;

    void Start()
    {
        initialYPos = transform.position.y;
    }

    void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, initialYPos + (Mathf.Sin(Time.time * hoverSpeed) / hoverDistance) + offset, transform.localPosition.z);
    }
}
