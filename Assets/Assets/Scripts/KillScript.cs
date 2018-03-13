using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillScript : MonoBehaviour {

    public CannonComponent playerObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == playerObject.name)
        {
            // prevent movement
            Debug.Log("CANNON OUT OF BOUNDS");
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
