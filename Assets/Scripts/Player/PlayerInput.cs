using UnityEngine;

[DefaultExecutionOrder(-100)]
public class PlayerInput : MonoBehaviour
{
    public bool clear;
    public float horizontal { get; private set; }
    public float vertical { get; private set; }
    public float mouseX { get; private set; }
    public float mouseY { get; private set; }
    public bool sprintInput { get; private set; }
    public bool jumpInput { get; private set; }
    public bool primaryInput { get; private set; }
    public bool secondaryInput { get; private set; }
    public bool interactInput { get; private set; }

    private static PlayerInput instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    private void Update()
    {
        ClearInput();
        ProcessInputs();
    }

    private void FixedUpdate()
    {
        clear = true;
    }

    public static PlayerInput GetInstance()
    {
        return instance;
    }

    void ProcessInputs()
    {
        if (!GameManager.GetInstance().IsInputActive())
            return;

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        sprintInput = sprintInput || Input.GetButton("Sprint");
        jumpInput = jumpInput || Input.GetButtonDown("Jump");

        interactInput = interactInput || Input.GetKeyDown(KeyCode.E);
        primaryInput = primaryInput || Input.GetButtonDown("Fire1");
        secondaryInput = secondaryInput || Input.GetButtonDown("Fire2");
    }

    void ClearInput()
    {
        if (!clear) return;

        horizontal = 0;
        vertical = 0;

        mouseX = 0;
        mouseY = 0;

        sprintInput = false;
        jumpInput = false;

        interactInput = false;
        primaryInput = false;
        secondaryInput = false;
    }
}