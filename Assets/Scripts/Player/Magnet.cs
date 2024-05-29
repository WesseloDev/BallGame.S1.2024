using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    private Collider magnetCollider;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float magnetSpeed;

    // Start is called before the first frame update
    void Start()
    {
        magnetCollider = GetComponent<Collider>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Coin>())
        {
            other.transform.position = Vector3.Lerp(other.transform.position, playerTransform.position, magnetSpeed * Time.deltaTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
