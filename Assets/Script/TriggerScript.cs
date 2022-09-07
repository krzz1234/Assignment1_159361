using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriggerScript : MonoBehaviour
{
    public bool AI_Scored = false;
    public bool Player_Scored =false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "ball"){
            GameObject ball = GameObject.FindGameObjectWithTag("ball");
            ball.transform.SetPositionAndRotation(new Vector3(0,5,0), Quaternion.identity);
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            rb.Sleep();
        }
        // Additonal Feature: Score
        if(gameObject.tag == "AI Side"){
            Player_Scored = true;
        }
        if(gameObject.tag == "Player Side"){
            AI_Scored = true;
        }
         
    }
}
