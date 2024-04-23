using System;
using UnityEngine;

public class MoveAlongEdge : MonoBehaviour
{
    private EdgeCollider2D edgeCollider;
    public event Action BallExit;
    private Vector2[] points;
    private int currentPointIndex = 0;
    private Vector2 targetPoint;
    private bool isMoving = false;
    private Vector2 initialRelativeVelocity;
    private PlayerToBallManager playerToBallManager;
    void Start()
    {
        // 获取父物体上的EdgeCollider2D组件
        playerToBallManager = PlayerToBallManager.Instance;
        edgeCollider = transform.parent.GetComponent<EdgeCollider2D>();

        
        // 获取EdgeCollider2D上的所有坐标点
        points = edgeCollider.points;
    }

    public void Move(Vector2 relativeVelocity)
    {
       
        // 设置移动状态为true
        isMoving = true;
        playerToBallManager.DisableInput();
        // 获取碰撞时的相对速度
        initialRelativeVelocity = relativeVelocity;

        // 设置目标点为下一个坐标点
        currentPointIndex++;
        if (currentPointIndex >= points.Length)
        {
            isMoving = false;
            ChridrenExit();

            return;
        }
        targetPoint = edgeCollider.transform.TransformPoint(points[currentPointIndex]);
    }

    void FixedUpdate()
    {
        // 如果正在移动
        if (isMoving)
        {
            // 移动到目标点
            transform.position = Vector2.MoveTowards(transform.position, targetPoint, initialRelativeVelocity.magnitude * Time.fixedDeltaTime);

            // 如果到达目标点
            if (Vector2.Distance(transform.position, targetPoint) < 0.01f)
            {
                // 更新目标点为下一个坐标点
                currentPointIndex++;
                if (currentPointIndex >= points.Length)
                {
                    isMoving = false;
                    ChridrenExit();
                   
                    return;
                }
                targetPoint = edgeCollider.transform.TransformPoint(points[currentPointIndex]);
            }
        }
    }
    public void SetFirstPlace(int firstIndex , int secondIndex ,Vector2 collisionPoint)
    {
        if (isMoving) return;
        currentPointIndex = firstIndex;
        Vector2 target1Point = edgeCollider.transform.TransformPoint(points[firstIndex]);
        Vector2 target2Point = edgeCollider.transform.TransformPoint(points[secondIndex]);
        targetPoint = FindClosestPointOnLine(collisionPoint, target1Point, target2Point);
        transform.position = targetPoint;
    }

    Vector2 FindClosestPointOnLine(Vector2 p, Vector2 p1, Vector2 p2)
    {
        // 计算 p1 到 p2 的向量
        Vector2 p1ToP2 = p2 - p1;

        // 计算 p1 到 p 的向量
        Vector2 p1ToP = p - p1;

        // 计算投影比例
        float dot = Vector2.Dot(p1ToP, p1ToP2) / Vector2.Dot(p1ToP2, p1ToP2);

        // 计算投影点的坐标
        Vector2 projection = p1 + dot * p1ToP2;

        // 限制投影点在 p1 和 p2 之间
        projection = Vector2.ClampMagnitude(projection - p1, (p2 - p1).magnitude) + p1;

        return projection;
    }


    public void BallChridren(Transform ball)
    {
        if (isMoving) return;
        ball.parent = transform;
    }
    private void ChridrenExit()
    {
        this.GetComponentsInChildren<Transform>()[1].parent = null;
        playerToBallManager.EnableInput();
        
        Ball.Instance.Sliding(false, 0);

        BallExit?.Invoke();
    }
}