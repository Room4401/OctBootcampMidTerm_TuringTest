using UnityEngine;

[RequireComponent(typeof(Camera))]
public class PlayerCamera : MonoBehaviour
{
    [Header("Player Camera")]
    [SerializeField] private float verticalTurnSpeed = 10f;
    [SerializeField] private bool invertMouse;

    private float camXRoatation;

    void Start()
    {
        //Hide Mouse
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        RotateCamera();
    }

    private void RotateCamera()
    {
        camXRoatation += (invertMouse ? 1 : -1) * verticalTurnSpeed
            * PlayerInput.GetInstance().mouseY * Time.deltaTime;
        camXRoatation = Mathf.Clamp(camXRoatation, -60.0f, 50.0f);

        transform.localRotation = Quaternion.Euler(camXRoatation, 0, 0);
    }
}