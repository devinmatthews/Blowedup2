using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillScript : MonoBehaviour {

    public CannonComponent playerObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CannonBall") ||
            other.CompareTag("Bullet") ||
            other.CompareTag("FlameWave"))
        {
            Destroy(other.gameObject);
        }
    }
}
