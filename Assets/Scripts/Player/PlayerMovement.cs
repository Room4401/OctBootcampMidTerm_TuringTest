using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float sprintMultiplier = 3f;
    [SerializeField] private float jumpVelocity = 2;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float checkDistance = 0.2f;
    [SerializeField] private float gravity = -9.81f;


    private CharacterController characterController;
    private PlayerInput playerInput;
    private Vector3 playerVelocity;
    public bool isGrounded { get; private set; }
    // Start is called before the first frame update
    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        playerInput = PlayerInput.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck();
        MovePlayer();
    }

    private void MovePlayer()
    {
        characterController.Move((transform.forward * playerInput.vertical
            + transform.right * playerInput.horizontal)
            * (playerInput.sprintInput ? sprintMultiplier : 1.0f)
            * moveSpeed * Time.deltaTime);

        VericalMovement();

        characterController.Move(playerVelocity * Time.deltaTime);
    }

    private void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, checkDistance, groundMask);
    }

    private void VericalMovement()
    {
        if (isGrounded)
        {
            if (playerInput.jumpInput)
                playerVelocity.y = jumpVelocity;

            if (playerVelocity.y < 0)
                playerVelocity.y = 0f;
        }
        playerVelocity.y += gravity * Time.deltaTime;
    }

    //public float GetForwasdSpeed()
    //{
    //    return playerInput.vertical * moveSpeed * Time.deltaTime
    //        * (playerInput.sprintInput ? sprintMultiplier : 1.0f);
    //}
}