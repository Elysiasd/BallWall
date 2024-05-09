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

    private float velocity;
    private bool isSliding;
    public float Velocity => isSliding ? velocity : RB.velocity.magnitude;

    public Rigidbody2D RB { get; private set; }
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
        RB = GetComponent<Rigidbody2D>();
        Effs = GetComponentsInChildren<ParticleSystem>();

        velocityReached = false;
    }
    private void FixedUpdate()
    {
        if (!velocityReached && Velocity > wallConfig.criticalVelocity)
        {
            velocityReached = true;
            OnBallReachVelocity?.Invoke();
            foreach (ParticleSystem p in Effs) p.Play();
        }
        if (velocityReached && Velocity < wallConfig.criticalVelocity)
        {
            velocityReached = false;
            OnBallReturnVelocity?.Invoke();
            foreach (ParticleSystem p in Effs) p.Stop();
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
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
            RB.velocity *= 1 - wallConfig.SpeedSlowRate;
        }

        //Debug.Log(CollisionManager.Instance.CollisionCnt);
    }

    public void Sliding(bool isSliding, float velocity)
    {
        this.isSliding = isSliding;
        this.velocity = velocity;
    }
    public void DestroySelf() => Destroy(gameObject);
}
