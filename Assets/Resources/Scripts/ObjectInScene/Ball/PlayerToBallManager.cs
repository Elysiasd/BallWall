using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UIElements;
using UnityEngine.Windows;

public class PlayerToBallManager : MonoSingleton<PlayerToBallManager>
{
    private bool ifInput;//是否允许输入
    private bool isTouching; // 是否有手指按下
    private Rigidbody2D rb;
    private Vector2 force;
    private Vector2 mouseDownPos;
    private Vector2 mouseUpPos;
    private Vector2 touchDownPos;
    private Vector2 touchUpPos;
    private BallAction ballAction;
    private float minDistance;
    void Start()
    {
        minDistance = 0.1f;
        ifInput = true;
        isTouching = false;
        rb = Ball.Instance.GetComponent<Rigidbody2D>();
        ballAction = new BallAction();
        ballAction.Common.Read.started += ctx =>
        {
            mouseDownPos = ballAction.Common.Move.ReadValue<Vector2>();
        };

        ballAction.Common.Read.started += ctx =>
        {
            // Capturing the initial touch position when the touch starts
            if (!isTouching)
            {
                Touchscreen ts = Touchscreen.current;
                if (ts != null)
                {

                    UnityEngine.Cursor.visible = false;
                    TouchControl tc = ts.touches[0];
                    touchDownPos = tc.startPosition.ReadValue();
                }
                else
                {

                    UnityEngine.Cursor.visible = true;//鼠标显示

                }
            }

        };
        ballAction.Common.Read.canceled += ctx =>
        {
            mouseUpPos = ballAction.Common.Move.ReadValue<Vector2>();
            force = mouseUpPos - mouseDownPos;
            if (ifInput) { rb.AddForce(force); }
        };
        ballAction.Common.Read.canceled += ctx =>
        {
            // Capturing the final touch position when the touch ends
            Touchscreen ts = Touchscreen.current;
            if (ts != null)
            {
                TouchControl tc = ts.touches[0];
                touchUpPos = tc.position.ReadValue();
                force = (touchUpPos - touchDownPos) /* Mathf.Log10
                    (10 + 10 * (ShopManager.Instance.buffs[Archive.Force] +
                    int.Parse(PlayerPrefs.GetString(Archive.Force, "0"))))*/;
                if (ifInput) { rb.AddForce(force); } // Applying the force to the Rigidbody
            }
        };
        ballAction.Common.Read.canceled += ctx =>
        {
            if (isTouching)
            {
                // Capturing the final touch position when the touch ends
                Touchscreen ts = Touchscreen.current;
                if (ts != null)
                {
                    TouchControl tc = ts.touches[0];
                    touchUpPos = tc.position.ReadValue();
                    isTouching = false;

                    // Calculating the distance between start and end positions
                    float distance = Vector2.Distance(touchDownPos, touchUpPos);

                    if (distance >= minDistance)
                    {
                        force = touchDownPos - touchUpPos;
                        if (ifInput) { rb.AddForce(force); } // Applying the force to the Rigidbody
                    }
                }
            }
        };
    }

    public void BanInput()
    {
        ifInput = false;
    }

    public void ResetInput()
    {
        ifInput = true;
    }
    private void OnDisable()
    {
        DisableInput();
    }
    public void DisableInput() => ballAction.Disable();
    public void EnableInput() => ballAction.Enable();

}


