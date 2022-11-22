using Newtonsoft.Json.Converters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) {
            transform.position += Vector3.forward * speed;
        } else if (Input.GetKey(KeyCode.S)) {
            transform.position -= Vector3.forward * speed;
        } else if (Input.GetKey(KeyCode.D)) {
            transform.position += Vector3.left * speed;
        } else if (Input.GetKey(KeyCode.A)) { 
            transform.position += Vector3.right * speed;
        }
    }
}
