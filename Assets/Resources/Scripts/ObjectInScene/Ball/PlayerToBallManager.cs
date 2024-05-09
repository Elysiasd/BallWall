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
    private Rigidbody2D rb;
    private Vector2 force;
    private Vector2 mouseDownPos;
    private Vector2 mouseUpPos;
    private Vector2 touchDownPos;
    private Vector2 touchUpPos;
    private BallAction ballAction;
    void Start()
    {
        ifInput = true;
        rb = Ball.Instance.GetComponent<Rigidbody2D>();
        ballAction = new BallAction();
        ballAction.Common.Read.started += ctx =>
        {
            mouseDownPos = ballAction.Common.Move.ReadValue<Vector2>();

        };

        ballAction.Common.Read.started += ctx =>
        {
            // Capturing the initial touch position when the touch starts
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
                force = (touchUpPos - touchDownPos) * Mathf.Log10
                    (10 + 10 * (ShopManager.Instance.buffs[Archive.Force] +
                    int.Parse(PlayerPrefs.GetString(Archive.Force, "0"))));
                if (ifInput) { rb.AddForce(force); } // Applying the force to the Rigidbody
            }
        };

    }
    void Update()
    {
        Touchscreen ts = Touchscreen.current;
        if (ts == null)
        {
            //Debug.Log("123");
            return;
        }
        else
        {
            TouchControl tc = ts.touches[0];
            if (tc.press.wasPressedThisFrame)
            {
                Debug.Log("按下");
            }
            if (tc.press.wasReleasedThisFrame)
            {
                Debug.Log("抬起");
            }
            if (tc.press.isPressed)
            {
                Debug.Log("按住");
            }
            if (tc.tap.isPressed)
            {

            }
            //点击次数 
            Debug.Log(tc.tapCount);
            //点击位置
            Debug.Log(tc.position.ReadValue());
            //第一次接触位置
            Debug.Log(tc.startPosition.ReadValue());
            //得到的范围
            Debug.Log(tc.radius.ReadValue());
            //偏移位置
            Debug.Log(tc.delta.ReadValue());
            //返回TouchPhase: None,Began,Moved,Ended,Canceled,Stationary
            Debug.Log(tc.phase.ReadValue());

            //判断状态
            UnityEngine.InputSystem.TouchPhase tp = tc.phase.ReadValue();
            switch (tp)
            {
                //无
                case UnityEngine.InputSystem.TouchPhase.None:
                    break;
                //开始接触
                case UnityEngine.InputSystem.TouchPhase.Began:
                    break;
                //移动
                case UnityEngine.InputSystem.TouchPhase.Moved:
                    break;
                //结束
                case UnityEngine.InputSystem.TouchPhase.Ended:
                    break;
                //取消
                case UnityEngine.InputSystem.TouchPhase.Canceled:
                    break;
                //静止
                case UnityEngine.InputSystem.TouchPhase.Stationary:
                    break;
            }
        }
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


