using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour, Input2.IActionsActions,Input2.IUtilsActions
{
    Input2 _input;
    public Vector2 mouseMov;
    public Vector2 movement;

    public bool isFire,isSliding;
    void Awake()
    {
        _input = new Input2();
        _input.Actions.SetCallbacks(this);
        _input.Enable();

    }

    void Start()
    {
        
    }

    public void OnChange(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();
    }

    public void OnEsc(InputAction.CallbackContext context)
    {
        //throw new NotImplementedException();
    }

    public void OnMouseButton(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isFire = true;
        }
        if (context.canceled) 
        {
            isFire = false;
        }
    }

    public void OnMousePos(InputAction.CallbackContext context)
    {
        //mouseMov = context.ReadValue<Vector2>();
    }

    public void OnMouseX(InputAction.CallbackContext context)
    {
        mouseMov.x=context.ReadValue<float>();
    }

    public void OnMouseY(InputAction.CallbackContext context)
    {
        mouseMov.y = context.ReadValue<float>();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    public void OnSliding(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isSliding = true;
        }
        if (context.canceled)
        {
            isSliding = false;
        }
    }

    public void OnSwap(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.performed)
        RPlayerMana.Instance.jumpAction();
    }
}
