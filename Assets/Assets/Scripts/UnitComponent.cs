using UnityEngine;

public class UnitComponent : MonoBehaviour {

    public long health;
    public float moveSpeed = 1f;

    protected MeshRenderer _meshRenderer;

    private WeaponComponent weaponClass;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
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

    private void OnDestroy()
    {
        Destroy(_meshRenderer);
    }
}
