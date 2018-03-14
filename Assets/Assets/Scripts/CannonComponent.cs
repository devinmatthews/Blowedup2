using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonComponent : UnitComponent {
	
	void Update () {

        if (Input.GetAxisRaw("Horizontal") > 0) // move right
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x + (moveSpeed * Time.deltaTime), -4.5f, 4.5f), transform.position.y, transform.position.z);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0) // move left
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x + (-moveSpeed * Time.deltaTime), -4.5f, 4.5f), transform.position.y, transform.position.z);
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetButton("Fire1"))
        {
            var spawnLocation = new Vector3(transform.position.x, transform.position.y, transform.position.z + transform.localScale.z / 2);
            FireWeapon(spawnLocation, Vector3.forward);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            // take health
            var projectile = other.gameObject.GetComponent<ProjectileComponent>();
            health -= projectile.damageDealt;

            // destroy bullet
            Destroy(other.gameObject);

            // destroy enemy if health is <= 0
            if (health <= 0)
                Die();
        }
    }
}
