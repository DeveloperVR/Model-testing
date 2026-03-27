using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    
    public PlayerController playerController;
    private InputAction _moveAction, _lookAction;
    void Start()
    {
        // _moveAction = InputSystem.actions.FindAction("Move");
        // _lookAction = InputSystem.actions.FindAction("Look");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
