using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float gravity;
    
    [SerializeField] private Transform cameraTransform;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundedDistance;

    private Rigidbody rb;
    private Vector3 input;

    [SerializeField] private GameObject magnet;
    [SerializeField] private float magnetTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (magnet.active && magnetTimer <= 0f)
        {
            magnet.SetActive(false);
        }
        else if (magnet.active)
        {
            magnetTimer -= Time.deltaTime;
            Debug.Log(magnetTimer);
        }

        input = new Vector3(Input.GetAxis("Horizontal"), IsGrounded() && Input.GetButton("Jump") ? jumpHeight : 0f, Input.GetAxis("Vertical"));
    }

    void FixedUpdate()
    {
        Movement();

        // gravity + clamp movement speed
        rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed), rb.velocity.y - gravity * Time.deltaTime, Mathf.Clamp(rb.velocity.z, -maxSpeed, maxSpeed));

        //transform.forward = new Vector3(direction.x, 0, direction.z);
    }
    private void Movement()
    {
        input = cameraTransform.TransformDirection(input);
        //input.Normalize();
        input = new Vector3(input.x * speed * Time.deltaTime, input.y, input.z * speed * Time.deltaTime);
        rb.AddForce(input, ForceMode.Impulse);
    }
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, groundedDistance, groundLayer);
    }

    public void AddMagnetTime(float timeToAdd)
    {
        if (!magnet.active)
        {
            magnet.SetActive(true);
        }

        magnetTimer += timeToAdd;
    }

}