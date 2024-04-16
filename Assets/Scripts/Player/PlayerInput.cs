using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[DefaultExecutionOrder(-100)]
public class PlayerInput : MonoBehaviour
{
    public float horizontal { get; private set; }
    public float vertical { get; private set; }
    public float mouseX { get; private set; }
    public float mouseY { get; private set; }
    public bool sprintInput { get; private set; }
    public bool jumpInput {  get; private set; }
    public bool primaryShoot {  get; private set; }
    public bool secondaryShoot {  get; private set; }
    public bool interactInput { get; private set; }

    public bool clear;

    private static PlayerInput instance;
    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        
        sprintInput = sprintInput || Input.GetButton("Sprint");
        jumpInput = jumpInput || Input.GetButtonDown("Jump");

        interactInput = interactInput || Input.GetKeyDown(KeyCode.E);
        primaryShoot = primaryShoot || Input.GetButtonDown("Fire1");
        secondaryShoot = secondaryShoot || Input.GetButtonDown("Fire2");
    }

    void ClearInput()
    {
        if(!clear) return;

        horizontal = 0;
        vertical = 0;

        mouseX = 0;
        mouseY = 0;

        sprintInput = false;
        jumpInput = false;

        interactInput = false;
        primaryShoot = false;
        secondaryShoot = false;
    }
}