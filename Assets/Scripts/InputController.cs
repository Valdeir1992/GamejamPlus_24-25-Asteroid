using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    public Action OnFirePress;
    public Action OnFireRelease;
    public Action<Vector2> OnMove;
    private GameInputs _gameInput;
    private Vector2 _direction;

    private void OnEnable()
    {
        _gameInput = new GameInputs(); 
        _gameInput.Enable();
        _gameInput.Gameplay.Move.performed += Move;
        _gameInput.Gameplay.Fire.started += FirePress;
        _gameInput.Gameplay.Fire.canceled += FireRelease;
    }
    private void Update()
    {
        OnMove?.Invoke(_direction);
    }
    private void Move(InputAction.CallbackContext ctx)
    {
        _direction = ctx.ReadValue<Vector2>(); 
    }
    private void FirePress(InputAction.CallbackContext ctx)
    {
        OnFirePress?.Invoke();
    }
    private void FireRelease(InputAction.CallbackContext ctx)
    {
        OnFireRelease?.Invoke();
    }
}
