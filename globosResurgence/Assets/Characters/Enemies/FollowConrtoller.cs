using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowConrtoller : MonoBehaviour
{

    public EnemyController[] mobArray;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (EnemyController mob in mobArray)
            {
                mob.followPlayer = true;
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            foreach(EnemyController mob in mobArray)
            {
                mob.followPlayer = false;
            }
        }
    }
}
