using UnityEngine;

public class UnitComponent : MonoBehaviour {

    public long health;
    public float moveSpeed = 1f;

    private WeaponComponent weaponClass;

    private void Awake()
    {
        weaponClass = GetComponent<WeaponComponent>();
    }

    protected virtual void FireWeapon(Vector3 spawnLocation, Vector3 direction)
    {
        weaponClass.Fire(spawnLocation, direction);
    }

    protected virtual void Die()
    {
        Destroy(this.gameObject);
    }
}
