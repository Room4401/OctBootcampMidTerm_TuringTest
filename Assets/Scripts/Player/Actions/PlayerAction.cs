using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAction : MonoBehaviour
{
    protected PlayerInput playerInput;

    private void Start()
    {
        playerInput = PlayerInput.GetInstance();
    }
    void Update()
    {
        TakeAction();
    }

    public abstract void TakeAction();
}