
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public Transform targetPosition;
    public float speed = 1.0f;
    public bool shouldMove = false;
    // Start is called before the first frame update
    public GameObject platformMove;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Nimbus")
        {
            platformMove.GetComponent<Animator>().Play("platform1");
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

}
