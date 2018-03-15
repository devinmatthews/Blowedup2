using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponComponent : MonoBehaviour {

    public bool trackAmmo;
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

    private Text ammoText;
    private AudioSource audioSource;

    private int roundsAvailable;
    private int RoundsAvailable // use property to update UI later on
    {
        get
        {
            return roundsAvailable;
        }
        set
        {
            roundsAvailable = value;

            if (trackAmmo)
                ammoText.text = "".PadLeft(value, 'O');
        }
    }

    private void Awake()
    {
        projectileClass = projectile.GetComponent<ProjectileComponent>();
        audioSource = GetComponent<AudioSource>();

        if (trackAmmo)
        {
            ammoText = GameObject.FindGameObjectWithTag("AmmoText").GetComponent<Text>();
        }
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
            audioSource.PlayOneShot(projectileClass.sound);
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
