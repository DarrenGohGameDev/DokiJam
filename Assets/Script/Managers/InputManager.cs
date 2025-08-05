using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public PlayerInputActions inputActions { get; private set; }

    public void Awake()
    {
        inputActions = new PlayerInputActions();
        inputActions.Enable();
    }

    public void OnDisable()
    {
        inputActions.Disable();
    }
}
