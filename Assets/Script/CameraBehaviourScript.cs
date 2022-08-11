using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviourScript : MonoBehaviour
{
    public GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X"), Space.Self);
        transform.GetChild(1).Rotate(Vector3.right, Input.GetAxis("Mouse Y"), Space.Self);
    }

    void LateUpdate() {
        transform.position = Target.transform.position;
    }
}
