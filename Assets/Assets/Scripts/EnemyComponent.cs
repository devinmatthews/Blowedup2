using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyComponent : UnitComponent {

    private void Update()
    {
        var spawnLocation = new Vector3(transform.position.x, transform.position.y, transform.position.z - transform.localScale.z / 2);
        FireWeapon(spawnLocation, Vector3.forward * -1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CannonBall")
        {
            // take health
            var projectile = other.gameObject.GetComponent<ProjectileComponent>();
            health -= projectile.damageDealt;

            // destroy cannonball
            Destroy(other.gameObject);

            // destroy enemy if health is <= 0
            if (health <= 0)
            {
                Die();
                LevelComponent.enemiesKilled++;
            }
        }
    }
}
