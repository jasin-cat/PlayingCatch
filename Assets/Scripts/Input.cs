using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Input :MonoBehaviour
{
    [SerializeField]
    InputAction _leftClick;
    [SerializeField]
    InputAction _forward;
    [SerializeField]
    InputAction _left;
    [SerializeField]
    InputAction _right;
    [SerializeField]
    InputAction _back;
    [SerializeField]
    Release _release;
    [SerializeField]
    PlayerMovement _movement;

    void Awake()
    {
        _leftClick.performed += OnLeftClick;
        _forward.performed += OnForward;
        _forward.canceled += ReverseForward;
        _left.performed += OnLeft;
        _left.canceled += ReverseLeft;
        _right.performed += OnRight;
        _right.canceled += ReverseRight;
        _back.performed += OnBack;
        _back.canceled += ReverseBack;

        _leftClick.Enable();
        _forward.Enable();
        _left.Enable();
        _right.Enable();
        _back.Enable();
    }

    void OnLeftClick(InputAction.CallbackContext context)
    {
        _release.ReleaseBall();
    }

    void OnForward(InputAction.CallbackContext context)
    {
        _movement.Forward();
    }

    void ReverseForward(InputAction.CallbackContext context)
    {
        _movement.ReverseForward();
    }

    void OnLeft(InputAction.CallbackContext context)
    {
        _movement.Left();
    }

    void ReverseLeft(InputAction.CallbackContext context)
    {
        _movement.ReverseLeft();
    }

    void OnRight(InputAction.CallbackContext context)
    {
        _movement.Right();
    }

    void ReverseRight(InputAction.CallbackContext context)
    {
        _movement.ReverseRight();
    }

    void OnBack(InputAction.CallbackContext context)
    {
        _movement.Back();
    }

    void ReverseBack(InputAction.CallbackContext context)
    {
        _movement.ReverseBack();
    }
}