using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
    public bool DestroyOnPickup = true;

    public virtual void OnCollected(GameObject collector)
    {
        if(DestroyOnPickup)
        {
            Destroy(gameObject);
        }
    }

    protected abstract bool CanInteractWith(GameObject other);

    private void OnTriggerEnter(Collider other)
    {
        if(CanInteractWith(other.gameObject))
        {
            OnCollected(other.gameObject);
        }
    }
}
