using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyComponent : UnitComponent {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CannonBall")
        {
            // take health
            var weapon = other.gameObject.GetComponent<WeaponComponent>();
            health -= weapon.damageDealt;

            // destroy cannonball
            Destroy(other.gameObject);

            // destroy enemy if health is <= 0
            if (health <= 0)
                Die();
        }
    }
}
