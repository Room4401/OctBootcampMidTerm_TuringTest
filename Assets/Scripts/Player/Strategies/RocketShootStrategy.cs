using UnityEngine;

public class RocketShootStrategy : IShootStrategy
{
    ShootAction shootAction;
    Transform shootPoint;

    public RocketShootStrategy(ShootAction _action)
    {
        Debug.Log("Switched to Rocket Mode");
        shootAction = _action;
        shootPoint = _action.GetShootPoint();
    }

    public void Shoot()
    {
        PooledObject pooledObject = shootAction.rocketPool.GetPooledObject();
        pooledObject.gameObject.SetActive(true);

        Rigidbody bullet = pooledObject.GetComponent<Rigidbody>();
        bullet.transform.position = shootPoint.position;
        bullet.transform.rotation = shootPoint.rotation;

        bullet.velocity = shootPoint.forward * shootAction.GetShootVelocity();

        shootAction.rocketPool.DestroyObjectFromPool(pooledObject, 5.0f);
    }
}