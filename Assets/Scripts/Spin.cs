using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 50f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }
}
