using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    public void ReactToHit() {
        StartCoroutine (Die());
    }
    private IEnumerator Die() {
        // Enemy falls over and disappears after two seconds
        iTween.RotateAdd (this.gameObject, new Vector3 (-75, -0, 0), 1);
    
        yield return new WaitForSeconds (1);

        Destroy (this.gameObject);
    }
}
