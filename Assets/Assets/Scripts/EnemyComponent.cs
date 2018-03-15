using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyComponent : UnitComponent {

    public float warpDelay;
    public long scoreOnKill;
    public bool isBoss;

    private float lastWarp;
    private float warpX;
    private float warpZ;

    private void Start()
    {
        lastWarp = Time.time;
    }

    private void Update()
    {
        if (lastWarp + warpDelay <= Time.time)
        {
            warpX = Random.Range(-4.7f, 4.7f);
            warpZ = Random.Range(2.8f, 4.7f);
            transform.position = new Vector3(warpX, 0f, warpZ);

            lastWarp = Time.time;
        }

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
            audioSource.PlayOneShot(damageTakenSound);

            // destroy cannonball
            Destroy(other.gameObject);

            // destroy enemy if health is <= 0
            if (health <= 0)
            {
                GameState.Score += scoreOnKill;
                LevelComponent.enemiesKilled++;
                Die();
            }
        }
    }
}
