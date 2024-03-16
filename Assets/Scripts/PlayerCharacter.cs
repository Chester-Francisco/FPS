using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{

    private float health;
    private float maxHealth = 5;

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
        health -= 1;
        Debug.Log("Health: " + health * .2f);
        Messenger<float>.Broadcast(GameEvent.HEALTH_CHANGED, health * .2f );
        

        if(health == 0) {
            Debug.Break();
        }
    }
}
