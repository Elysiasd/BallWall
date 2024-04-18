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
        // ��ȡ�������ϵ�EdgeCollider2D���
        playerToBallManager = PlayerToBallManager.Instance;
        edgeCollider = transform.parent.GetComponent<EdgeCollider2D>();

        
        // ��ȡEdgeCollider2D�ϵ����������
        points = edgeCollider.points;
    }

    public void Move(Vector2 relativeVelocity)
    {
       
        // �����ƶ�״̬Ϊtrue
        isMoving = true;
        playerToBallManager.DisableInput();
        // ��ȡ��ײʱ������ٶ�
        initialRelativeVelocity = relativeVelocity;

        // ����Ŀ���Ϊ��һ�������
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
        // ��������ƶ�
        if (isMoving)
        {
            // �ƶ���Ŀ���
            transform.position = Vector2.MoveTowards(transform.position, targetPoint, initialRelativeVelocity.magnitude * Time.fixedDeltaTime);

            // �������Ŀ���
            if (Vector2.Distance(transform.position, targetPoint) < 0.01f)
            {
                // ����Ŀ���Ϊ��һ�������
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
        // ���� p1 �� p2 ������
        Vector2 p1ToP2 = p2 - p1;

        // ���� p1 �� p ������
        Vector2 p1ToP = p - p1;

        // ����ͶӰ����
        float dot = Vector2.Dot(p1ToP, p1ToP2) / Vector2.Dot(p1ToP2, p1ToP2);

        // ����ͶӰ�������
        Vector2 projection = p1 + dot * p1ToP2;

        // ����ͶӰ���� p1 �� p2 ֮��
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