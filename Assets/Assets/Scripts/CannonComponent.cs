using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonComponent : UnitComponent {

    public Material cannon_75;
    public Material cannon_50;
    public Material cannon_25;

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

            if (health >= 75)
                _meshRenderer.material = cannon_75;
            else if (health >= 50)
                _meshRenderer.material = cannon_50;
            else if (health >= 1)
                _meshRenderer.material = cannon_25;
            else
                Die();
        }
    }
}
