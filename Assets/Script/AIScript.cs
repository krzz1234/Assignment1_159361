using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScript : MonoBehaviour
{
    private Rigidbody rb, ballRb;
    private Vector3 startingPos;
    public float speed;
    public GameObject ball;
    // bool right = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startingPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // if(transform.position.z <= -7.5){
        //     right = true;
        // }
        // else if(transform.position.z >= 7.5){
        //     right = false;
        // }
        // if(right){
        //     rb.velocity = transform.right + new Vector3(0, 0, speed);
        // }
        // else if(!right)
        // {rb.velocity = transform.right + new Vector3(0, 0, -speed);}
        // if(Vector3.Distance(transform.position, ball.transform.position) <= 1.0f){
        //     transform.position = transform.position;
        // }
        if(Vector3.Distance(startingPos, transform.position) > 10.0f){
            transform.position = Vector3.MoveTowards(transform.position, startingPos, speed * Time.deltaTime);
        }
        if(Vector3.Distance(transform.position, ball.transform.position) <= 10.0f && Vector3.Distance(transform.position, ball.transform.position) > 1.0f){
            transform.position = Vector3.MoveTowards(transform.position,ball.transform.position+new Vector3(0,1.15f,0),speed * Time.deltaTime);
        }
        if(Vector3.Distance(transform.position, ball.transform.position) < 2.0f){
            ballRb = ball.GetComponent<Rigidbody>();
            ballRb.AddForce(transform.forward * 2.0f, ForceMode.Force);
        }
    }
}
