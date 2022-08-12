using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float Sensitivity = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * Sensitivity, Space.World);
        transform.Rotate(Vector3.right, -Input.GetAxis("Mouse Y") * Sensitivity, Space.Self);   
    }
}
