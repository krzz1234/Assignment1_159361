using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviourScript : MonoBehaviour
{
    public float Speed = 20.0f;
    public float Strength = 1.0f;
    public GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Input.GetAxis("Vertical") * Time.deltaTime * Speed;
        transform.position += transform.right * Input.GetAxis("Horizontal") * Time.deltaTime * Speed;

        Rigidbody rb = Target.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * Strength, ForceMode.Impulse);
    }
}
