using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponComponent : MonoBehaviour {
    
    public int roundCapacity;
    public float roundReloadDelay;
    public float roundFireDelay;

    public Rigidbody projectile;

    private ProjectileComponent projectileClass;

    private float lastReload;
    private float lastFire;

    private bool pinAction;
    private Vector3 spawnLocation;
    private Vector3 direction;

    //private static int roundsAvailable;
    private static int RoundsAvailable // use property to update UI later on
    {
        get; set;
    }

    private void Awake()
    {
        projectileClass = projectile.GetComponent<ProjectileComponent>();
    }

    private void Start()
    {
        RoundsAvailable = roundCapacity;
    }

    private void Update()
    {
        if (RoundsAvailable < roundCapacity &&
            lastReload + roundReloadDelay <= Time.time)
        {
            // reload a round
            RoundsAvailable++;
            lastReload = Time.time;
        }

        //Debug.Log(RoundsAvailable.ToString());
    }

    private void FixedUpdate()
    {
        if (pinAction && RoundsAvailable > 0 &&
            lastFire + roundFireDelay <= Time.time)
        {
            // fire a round
            var projectileSpawn = Instantiate(projectile, spawnLocation, Quaternion.identity);
            projectileSpawn.AddForce(direction * projectileClass.projectileSpeed, ForceMode.VelocityChange);

            RoundsAvailable--;
            lastFire = Time.time;
        }

        pinAction = false;
    }

    public void Fire(Vector3 spawnLoc, Vector3 dir)
    {
        spawnLocation = spawnLoc;
        direction = dir;
        pinAction = true;
    }
}
