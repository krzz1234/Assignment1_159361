using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviourScript : MonoBehaviour
{
    public float Strength = 1.0f;
    
    // Rigidbody Component
    private Rigidbody rb;

    // Mouse Sensitivity
    public float Sensitivity = 1.0f;

    // Player Speed
    public float Speed = 5.0f;

    // Start - called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update - called once per frame
    void Update() {
    

    }

    // FixedUpdate - called oncer per physics frame
    void FixedUpdate() {
        Vector3 forward = transform.forward - Vector3.up * Vector3.Dot(transform.forward, Vector3.up);

        rb.velocity = forward * Input.GetAxis("Vertical") * Speed + transform.right * Input.GetAxis("Horizontal") * Speed;
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, Speed);

    }

}
