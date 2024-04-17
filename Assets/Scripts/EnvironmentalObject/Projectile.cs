using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private bool isRocket;
    private PooledObject pooledObject;

    private void OnEnable()
    {
        if(!isRocket)
            GetComponent<Rigidbody>().useGravity = false;
    }

    private void Start()
    {
        pooledObject = GetComponent<PooledObject>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        IDestroyable destroyable = collision.gameObject.GetComponent<IDestroyable>();
        if (destroyable != null)
        {
            destroyable.OnCollided();
            pooledObject.Destroy();
        }
        if (isRocket)
            pooledObject.Destroy();
        else
            GetComponent<Rigidbody>().useGravity = true;
    }
}