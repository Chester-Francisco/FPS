using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public enum RotationAxes {
        MouseXAndY,
        MouseX,
        MouseY
    }

    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityHoriz = 9.0f;


    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (axes == RotationAxes.MouseX) {
            float deltaHoriz = Input.GetAxis("Mouse X") * sensitivityHoriz;
            transform.Rotate(Vector3.up * deltaHoriz);
        } else if (axes == RotationAxes.MouseY) {
            //vertical rotation here
        } else {
            // both vert and horiz rotation here
        }
    }
}
