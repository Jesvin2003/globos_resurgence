using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform2Trigger : MonoBehaviour
{
    public GameObject platform2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Button triggered by player");
            platform2.GetComponent<Animator>().Play("platform2");
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }


}
