using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
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
    }
}
