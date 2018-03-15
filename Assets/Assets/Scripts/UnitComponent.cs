using UnityEngine;

public class UnitComponent : MonoBehaviour {

    public long health;
    public AudioClip damageTakenSound;

    protected MeshRenderer _meshRenderer;
    protected AudioSource audioSource;

    private WeaponComponent weaponClass;

    protected virtual void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        weaponClass = GetComponent<WeaponComponent>();
        audioSource = GetComponent<AudioSource>();
    }

    protected virtual void FireWeapon(Vector3 spawnLocation, Vector3 direction)
    {
        weaponClass.Fire(spawnLocation, direction);
    }

    protected virtual void Die()
    {
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        Destroy(_meshRenderer);
    }
}
