using UnityEngine;

public class ShootAction : PlayerAction
{
    [Header("Player Shoot")]
    public ObjectPool bulletPool;
    public ObjectPool rocketPool;

    [SerializeField] private float shootVelocity;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private PlayerMovement playerMovement;

    private float finalShootVelocity;
    private IShootStrategy currentShootStrategy;

    public Transform GetShootPoint()
    {
        return shootPoint;
    }

    public override void TakeAction()
    {
        if (currentShootStrategy == null)
        {
            currentShootStrategy = new BulletShootStrategy(this);
        }

        //Change Strategy
        if (playerInput.primaryInput)
        {
            currentShootStrategy = new BulletShootStrategy(this);
            currentShootStrategy.Shoot();
        }
        if (playerInput.secondaryInput)
        {
            currentShootStrategy = new RocketShootStrategy(this);
            currentShootStrategy.Shoot();
        }
    }

    public float GetShootVelocity()
    {
        finalShootVelocity = playerMovement.GetForwardSpeed() + shootVelocity;
        return finalShootVelocity;
    }
}