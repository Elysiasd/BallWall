using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoSingleton<Ball>
{
    /// <summary>
    /// 撞到墙的事件
    /// </summary>
    public event Action OnBallCollision;

    public float velocity { get; private set; }
    private Vector2 curPos;
    private Vector2 lastPos;

    public ParticleSystem[] Effs { get; private set; }

    /// <summary>
    /// 弹珠达到墙壁被破坏速度
    /// </summary>
    public event Action OnBallReachVelocity;
    /// <summary>
    /// 弹珠速度降低至不能破坏墙壁
    /// </summary>
    public event Action OnBallReturnVelocity;
    private bool velocityReached;
    [SerializeField] private BrokenWallConfig wallConfig;
    private void Start()
    {
        Effs = GetComponentsInChildren<ParticleSystem>();

        velocityReached = false;
        curPos = lastPos = transform.position;
    }
    private void FixedUpdate()
    {
        curPos = transform.position;
        velocity = Vector2.Distance(curPos, lastPos) / Time.fixedDeltaTime;
        lastPos = curPos;
        if (!velocityReached && velocity > wallConfig.criticalVelocity)
        {
            velocityReached = true;
            OnBallReachVelocity?.Invoke();
            foreach (ParticleSystem p in Effs) p.Play();
        }
        if (velocityReached && velocity < wallConfig.criticalVelocity)
        {
            velocityReached = false;
            OnBallReturnVelocity?.Invoke();
            foreach (ParticleSystem p in Effs) p.Stop();
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall")) { OnBallCollision?.Invoke(); }
        if (other.gameObject.CompareTag("Wall"))
        {
            OnBallCollision?.Invoke();
        }

        //Debug.Log(CollisionManager.Instance.CollisionCnt);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            rb.velocity *= 1-wallConfig.speedSlowRate;
        }

        //Debug.Log(CollisionManager.Instance.CollisionCnt);
    }
}
