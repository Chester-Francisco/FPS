using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{

    private float health;
    private float maxHealth = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hit() {
        health -= .2f;
        Debug.Log("Health: " + health);
        Messenger<float>.Broadcast(GameEvent.HEALTH_CHANGED, health);
        

        if(health == 0) {
            Debug.Break();
        }
    }
}
