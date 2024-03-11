using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ReactiveTarget : MonoBehaviour {

    private bool isAlive = true;
    public void ReactToHit() {

        if (isAlive)
        {
            WanderingAI enemyAi = GetComponent<WanderingAI>();
            if (enemyAi != null)
            {
                enemyAi.ChangeState(EnemyStates.dead);
            }

            Animator enemyAnimator = GetComponent<Animator>();
            if (enemyAnimator != null)
            {
                enemyAnimator.SetTrigger("Die");

            }

            isAlive = false;
            Messenger.Broadcast(GameEvent.ENEMY_DEAD);
        }
       
    }

    private IEnumerator Die() {
        // Enemy falls over and disappears after two seconds
        //iTween.RotateAdd (this.gameObject, new Vector3 (-75, -0, 0), 1);
    
        yield return new WaitForSeconds (1);

        Destroy (this.gameObject);
    }

    private void DeadEvent()
    {
        Destroy(this.gameObject);
    }
}
