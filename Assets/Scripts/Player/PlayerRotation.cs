using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [Header("Player Rotation")]
    [SerializeField] private float horizontalTurnSpeed = 10f;

    void Update()
    {
        RotatePlayer();
    }

    private void RotatePlayer()
    {
        transform.Rotate(Vector3.up * horizontalTurnSpeed
            * PlayerInput.GetInstance().mouseX
            * Time.deltaTime);
    }
}