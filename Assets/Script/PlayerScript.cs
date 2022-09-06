using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Reference https://docs.unity3d.com/Manual/WheelColliderTutorial.html
public class PlayerScript : MonoBehaviour
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public Transform leftWheel_Transform;
    public Transform rightWheel_Transform;
    public float maxSteeringAngle = 10.0f;
    public float maxMotorTorque = 20.0f;
    public float boost = 30.0f;
    private float horizontal_Input;
    private float Vertical_Input;
    private float steeringAngle;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        // Input from the user
        horizontal_Input = Input.GetAxis("Horizontal");
        Vertical_Input = Input.GetAxis("Vertical");
        // Update steerAngle
        steeringAngle = maxSteeringAngle * horizontal_Input;
        leftWheel.steerAngle = steeringAngle;
        rightWheel.steerAngle = steeringAngle;
        // Update Acceleration
        leftWheel.motorTorque = Vertical_Input * maxMotorTorque;
        rightWheel.motorTorque = Vertical_Input * maxMotorTorque;

        UpdateWheelPose(leftWheel, leftWheel_Transform);
        UpdateWheelPose(rightWheel, rightWheel_Transform);        

        Vector3 forward = transform.forward - Vector3.up * Vector3.Dot(transform.forward, Vector3.up);

        rb.velocity = forward * Input.GetAxis("Vertical") * maxMotorTorque + transform.right * Input.GetAxis("Horizontal") * maxMotorTorque;
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxMotorTorque);
        transform.Rotate(Vector3.up, Input.GetAxis("RotateHorizontal") * Time.deltaTime * 360, Space.World);

        if(Input.GetButton("Boost")){
            rb.velocity = forward * Input.GetAxis("Vertical") * boost + transform.right * Input.GetAxis("Horizontal") * boost;
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, boost);
            transform.Rotate(Vector3.up, Input.GetAxis("RotateHorizontal") * Time.deltaTime * 360, Space.World);

        }
    }

    void UpdateWheelPose(WheelCollider _collider, Transform _transform) 
    {
        Vector3 pos = _transform.position;
        Quaternion quat = _transform.rotation;

        _collider.GetWorldPose(out pos, out quat);

        _transform.position = pos;
        _transform.rotation = quat; 
    }

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "ball"){
            other.rigidbody.AddForce(transform.forward * 1.0f, ForceMode.Force);
        }
    }
}
