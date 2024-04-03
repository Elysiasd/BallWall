using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerToBallManager : MonoSingleton<PlayerToBallManager>
{
    private Rigidbody2D rb;
    private Vector2 force;
    private Vector2 mouseDownPos;
    private Vector2 mouseUpPos;
    private BallAction ballAction;
    void Start()
    {

        ballAction = new BallAction();
        ballAction.Enable();
        ballAction.Common.Read.started += ctx =>
        {
            mouseDownPos = ballAction.Common.Move.ReadValue<Vector2>();
            
        };
            ballAction.Common.Read.canceled += ctx =>
        {
            mouseUpPos = ballAction.Common.Move.ReadValue<Vector2>();
            force = mouseUpPos - mouseDownPos;
            rb.AddForce(force);
            
        };
        rb = Ball.Instance.GetComponent<Rigidbody2D>();
    }

    private void OnDisable()
    {
        DisableInput();
    }
    public void DisableInput() => ballAction.Disable();
    public void EnableInput() => ballAction.Enable();

}
