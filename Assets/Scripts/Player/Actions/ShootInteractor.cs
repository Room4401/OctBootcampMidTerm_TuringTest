using UnityEngine;

public class ShootInteractor : PlayerAction
{
    [Header("Gun")]
    public MeshRenderer gunRenderer;
    public Color bulletGunColor;
    public Color rocketGunColor;

    //[Header("Player Shoot")]
    //public ObjectPool bulletPool;
    //public ObjectPool rocketPool;



    [SerializeField] private Rigidbody bulletPrefab;
    [SerializeField] private float shootVelocity;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private PlayerMovement playerMovement;

    private float finalShootVelocity;
    private IShootStrategy currentShootStrategy;

    [SerializeField] private InputType inputType;
    public enum InputType
    {
        Primary,
        Secondary,
    }

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
        //if (playerInput.weapon1Pressed)
        //{
        //    currentShootStrategy = new BulletShootStrategy(this);
        //}

        //if (playerInput.weapon2Pressed)
        //{
        //    currentShootStrategy = new RocketShootStrategy(this);
        //}

        ////Shoot with selected strategy

        //if (playerInput.primaryButtonPressed && currentShootStrategy != null)
        //{
        //    currentShootStrategy.Shoot();
        //}
    }

    public float GetShootVelocity()
    {
        finalShootVelocity = playerMovement.GetForwardSpeed() + shootVelocity;
        return finalShootVelocity;
    }
}
