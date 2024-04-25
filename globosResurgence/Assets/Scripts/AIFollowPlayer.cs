using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFollowPlayer : MonoBehaviour
{
    /*
     * Target will be set as the tag "Player" which can be done in GameObject (Nimbus or Atmos)
     * movement speed which can be modified under the character where the script component is
     * Maximum distane to be from the user
     * Minimum distance to maintain from user
     */
    public Transform target;
    public float moveSpeed = 3f;
    public float maxDistance = 5f;
    public float minDistance = 3f;

    void Start()
    {
        //get player character GameObject and set it as the target for AI to follow
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            //this gets the distance from the player and stores it in a float variable (not int, then AI will freak out to maintain exact int)
            float distanceToPlayer = Vector3.Distance(transform.position, target.position);

            //if cases to see if AI needs to either seperate or come towards player depending on max and min distance
            if(distanceToPlayer > maxDistance)
            {
                MoveTowardsPlayer();
            }
            else if(distanceToPlayer < minDistance)
            {
                MoveAwayFromPlayer();
            }

            //checks if AI needs to turn around (if looking right turn left, vise versa)
            Vector3 directionToPlayer = (target.position - transform.position).normalized;
            Vector3 forwardDir = transform.right;


            if(Vector3.Dot(directionToPlayer, forwardDir) < 0)
            {
                //if player is behind the AI, turn around by rotating 180 degrees on y-axis
                transform.Rotate(0, 180, 0);
            }
        }
    }
    //in these, i can code in the animations once i figure out how to get them working
    void MoveTowardsPlayer()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime; 
    }

    void MoveAwayFromPlayer()
    {
        Vector3 direction = (transform.position - target.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}
