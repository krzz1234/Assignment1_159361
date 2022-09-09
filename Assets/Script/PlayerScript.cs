using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Reference https://docs.unity3d.com/Manual/WheelColliderTutorial.html
public class PlayerScript : MonoBehaviour
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public Transform leftWheel_Transform;
    public Transform rightWheel_Transform;
    public Slider BoosterSlider;
    public TMP_Text Score;
    public TriggerScript Player_side;
    public TriggerScript AI_side;
    public GameObject Ball;
    public float maxSteeringAngle = 10.0f;
    public float maxMotorTorque = 20.0f;
    public float boost = 30.0f;
    private float horizontal_Input;
    private float Vertical_Input;
    private float steeringAngle;
    private int Player = 0;
    private int AI = 0;
    private Vector3 initialPosition;

    private Rigidbody rb;
    private Rigidbody rb_Ball;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb_Ball = Ball.GetComponent<Rigidbody>();

        initialPosition = transform.position;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;   
    }

    // Update is called once per frame
    void Update()
    {
        // Additional Feature: Score
        if(AI_side.Player_Scored){
            Player += 1;
            AI_side.Player_Scored = false;
        }
        if(Player_side.AI_Scored){
            AI += 1;
            Player_side.AI_Scored = false;
        }
        Score.text = "PLAYER " + Player + " : " + AI + " AI";

        // Aditional Feature: Resset position
        if(Input.GetKey("r")){
            transform.position = initialPosition;
            Ball.transform.position = new Vector3(0, 0, 0);
            rb_Ball.velocity = new Vector3(0, 0, 0);
        }
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

        // Additional feature: Booster
        if(Input.GetKey("space") && BoosterSlider.value > 0.0f){
            rb.velocity = forward * Input.GetAxis("Vertical") * boost + transform.right * Input.GetAxis("Horizontal") * boost;
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, boost);
            transform.Rotate(Vector3.up, Input.GetAxis("RotateHorizontal") * Time.deltaTime * 360, Space.World);
            BoosterSlider.value -= 0.3f;
        }
        if(!Input.GetKey("space")) {
            BoosterSlider.value += 0.05f;
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
