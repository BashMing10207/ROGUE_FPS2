using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public enum InputType
{
    Movement,MouseX,MouseY
}

public class RPlayerMana : MonoBehaviour
{
    public static RPlayerMana Instance;
    public Dictionary<InputType, UnityAction<InputAction.CallbackContext>> Inputs;

    public PlayerInput playerInput;
    public PlayerMovement playerMovement;

    public UnityAction jumpAction;

    private void Awake()
    {
        
        Instance = this;
        playerInput = GetComponent<PlayerInput>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    
}
