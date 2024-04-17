using UnityEngine;

public class BulletShootStrategy : IShootStrategy
{
    ShootAction shootAction;
    Transform shootPoint;

    public BulletShootStrategy(ShootAction _action)
    {
        Debug.Log("Switched to Bullet");
        shootAction = _action;
        shootPoint = _action.GetShootPoint();
    }

    public void Shoot()
    {
        PooledObject pooledObject = shootAction.bulletPool.GetPooledObject();
        pooledObject.gameObject.SetActive(true);

        Rigidbody bullet = pooledObject.GetComponent<Rigidbody>();
        bullet.transform.position = shootPoint.position;
        bullet.transform.rotation = shootPoint.rotation;

        bullet.velocity = shootPoint.forward * shootAction.GetShootVelocity();

        shootAction.bulletPool.DestroyObjectFromPool(pooledObject, 5.0f);
    }
}