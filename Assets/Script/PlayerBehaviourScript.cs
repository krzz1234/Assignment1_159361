using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Reference https://docs.unity3d.com/Manual/WheelColliderTutorial.html
[System.Serializable]
public class AxleInfo {
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steering;
}
public class PlayerBehaviourScript : MonoBehaviour
{
    //Reference https://docs.unity3d.com/Manual/WheelColliderTutorial.html
    public List<AxleInfo> axleInfos; 
    public float maxMotorTorque;
    public float maxSteeringAngle;
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
    //Reference https://docs.unity3d.com/Manual/WheelColliderTutorial.html
    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
     
        Transform visualWheel = collider.transform.GetChild(0);
     
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);
     
        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }

    // FixedUpdate - called oncer per physics frame
    void FixedUpdate() {
        Vector3 forward = transform.forward - Vector3.up * Vector3.Dot(transform.forward, Vector3.up);

        rb.velocity = forward * Input.GetAxis("Vertical") * Speed + transform.right * Input.GetAxis("Horizontal") * Speed;
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, Speed);

        //Reference https://docs.unity3d.com/Manual/WheelColliderTutorial.html
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");
     
        foreach (AxleInfo axleInfo in axleInfos) {
            if (axleInfo.steering) {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor) {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);
        }

    }

}
