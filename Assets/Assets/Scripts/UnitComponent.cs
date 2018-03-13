using UnityEngine;

public class UnitComponent : MonoBehaviour {

    public long health;

    protected virtual void Die()
    {
        Destroy(this.gameObject);
    }
}
