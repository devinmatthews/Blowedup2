using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonComponent : UnitComponent {

    public GameObject floor;
    public float moveSpeed = 1f;
    public Rigidbody projectile;
    public float projectileSpeed = 1f;
	
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
        if (Input.GetButtonDown("Fire1"))
        {
            var spawnLocation = new Vector3(transform.position.x, transform.position.y, transform.position.z + transform.localScale.z / 2);
            var projectileSpawn = Instantiate(projectile, spawnLocation, Quaternion.identity);
            projectileSpawn.AddForce(transform.forward * projectileSpeed);
        }
    }
}
