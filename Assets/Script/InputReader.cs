using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.DefaultInputActions;

public class InputReader : MonoBehaviour
{
    public Vector2 MoveComposite;

    GamePlayManager gamePlayManager;

    bool isDreg = false;

    Vector2 cuttDirection;
    Vector2 prevPos = Vector3.zero;

    private void Start()
    {
        gamePlayManager = FindAnyObjectByType<GamePlayManager>();
    }

    private void Update()
    {
         MoveComposite = new Vector2(gamePlayManager.variableJoystick.Horizontal, gamePlayManager.variableJoystick.Vertical);
    }
}
