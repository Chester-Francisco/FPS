using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour {

    public float speed = 0;
    private Rigidbody rb;
    float horizInput;
    float vertInput;
    

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update() {
         horizInput = Input.GetAxis("Horizontal");
         vertInput = Input.GetAxis("Vertical");
    }

    void FixedUpdate() {
        Vector3 movement = new Vector3( horizInput, 0, vertInput )  * speed * Time.deltaTime * 100;
        rb.velocity = movement;
        // rb.AddForce(movement);
    }
}
