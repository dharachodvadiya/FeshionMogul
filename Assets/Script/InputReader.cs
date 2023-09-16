using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static Controls;
using static UnityEngine.InputSystem.DefaultInputActions;

public class InputReader : MonoBehaviour, IGameActions
{
    public Controls inputControls;

    public Vector2 MoveComposite;

    private void OnEnable()
    {
        if (inputControls == null)
        {
            inputControls = new Controls();
            inputControls.Game.SetCallbacks(this);
        }
        inputControls.Game.Enable();
    }

    private void OnDisable()
    {
        inputControls.Disable();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        MoveComposite = context.ReadValue<Vector2>();

       // Debug.Log(MoveComposite);
    }
}
