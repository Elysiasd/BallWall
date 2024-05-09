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
    private bool ifInput;//�Ƿ���������
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

                UnityEngine.Cursor.visible = true;//�����ʾ

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
                Debug.Log("����");
            }
            if (tc.press.wasReleasedThisFrame)
            {
                Debug.Log("̧��");
            }
            if (tc.press.isPressed)
            {
                Debug.Log("��ס");
            }
            if (tc.tap.isPressed)
            {

            }
            //������� 
            Debug.Log(tc.tapCount);
            //���λ��
            Debug.Log(tc.position.ReadValue());
            //��һ�νӴ�λ��
            Debug.Log(tc.startPosition.ReadValue());
            //�õ��ķ�Χ
            Debug.Log(tc.radius.ReadValue());
            //ƫ��λ��
            Debug.Log(tc.delta.ReadValue());
            //����TouchPhase: None,Began,Moved,Ended,Canceled,Stationary
            Debug.Log(tc.phase.ReadValue());

            //�ж�״̬
            UnityEngine.InputSystem.TouchPhase tp = tc.phase.ReadValue();
            switch (tp)
            {
                //��
                case UnityEngine.InputSystem.TouchPhase.None:
                    break;
                //��ʼ�Ӵ�
                case UnityEngine.InputSystem.TouchPhase.Began:
                    break;
                //�ƶ�
                case UnityEngine.InputSystem.TouchPhase.Moved:
                    break;
                //����
                case UnityEngine.InputSystem.TouchPhase.Ended:
                    break;
                //ȡ��
                case UnityEngine.InputSystem.TouchPhase.Canceled:
                    break;
                //��ֹ
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


