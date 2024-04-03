using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoSingleton<Ball>
{
    /// <summary>
    /// ײ��ǽ���¼�
    /// </summary>
    public event Action OnBallCollision;
    private Rigidbody2D rb;
    
    /// <summary>
    /// ����ﵽǽ�ڱ��ƻ��ٶ�
    /// </summary>
    public event Action OnBallReachVelocity;
    /// <summary>
    /// �����ٶȽ����������ƻ�ǽ��
    /// </summary>
    public event Action OnBallReturnVelocity;
    private bool velocityReached;
    [SerializeField] private BrokenWallConfig wallConfig;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        velocityReached = false;
    }
    private void FixedUpdate()
    {
        if (!velocityReached && rb.velocity.magnitude > wallConfig.criticalVelocity)
        {
            velocityReached = true;
            OnBallReachVelocity?.Invoke();
        }
        if (velocityReached && rb.velocity.magnitude < wallConfig.criticalVelocity)
        {
            velocityReached = false;
            OnBallReturnVelocity?.Invoke();
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall")){ OnBallCollision?.Invoke(); }
        //Debug.Log(CollisionManager.Instance.CollisionCnt);
    }
}
