using System;
using UnityEditor;
using UnityEngine;

public class SlideWall : MonoBehaviour
{
    [SerializeField] private SlideWallConfig config;
    
    private bool isBallCollison;
    private Rigidbody2D ballRb;
    private MoveAlongEdge moveScript;
    private int nearPointIndex;
    private int near2PointIndex;
    private Vector2 initialRelativeVelocity;
    private Vector2[] points;
    private EdgeCollider2D edgeCollider;
    private void Start()
    {
        // ��ȡ�������ϵ�Rigidbody2D���
        edgeCollider = GetComponent<EdgeCollider2D>();
        points = edgeCollider.points;

        isBallCollison = false;
        // ��ȡ�������ϵ�MoveAlongEdge�ű�
        moveScript = GetComponentInChildren<MoveAlongEdge>();
        moveScript.BallExit += () => { isBallCollison = false; ballRb.velocity = initialRelativeVelocity.magnitude *
            (points[points.Length - 1] - points[points.Length - 2]).normalized * config.finalSpeedRate; } ;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ball")) return;
        if (isBallCollison) return;
        isBallCollison=true;
        ballRb = collision.gameObject.GetComponent<Rigidbody2D>();
        initialRelativeVelocity = collision.relativeVelocity;
        ballRb.velocity = Vector2.zero;
        Vector2 collisionPoint = collision.GetContact(0).point;

        // �ҵ�����ײ�������EdgeCollider2D�ϵ������
        
        float minDistance = Mathf.Infinity;
        Vector2 closestPoint = Vector2.zero;
        for (int i = 0; i < points.Length; i++)
        {
            Vector2 point = edgeCollider.transform.TransformPoint(points[i]);
            float distance = Vector2.Distance(collisionPoint, point);

            if (distance < minDistance)
            {
                minDistance = distance;
                closestPoint = point;
                nearPointIndex = i;
            }
        }
        if (nearPointIndex == 0) { near2PointIndex = 1; }
        else if (nearPointIndex == points.Length-1) { near2PointIndex = nearPointIndex - 1; }
        else { near2PointIndex = (Vector2.Distance(collisionPoint, points[nearPointIndex - 1]) < 
                Vector2.Distance(collisionPoint, points[nearPointIndex + 1])) ? nearPointIndex - 1 : nearPointIndex + 1; }

        // ��ȡ��ײʱ������ٶ�
        
        moveScript.SetFirstPlace(nearPointIndex , near2PointIndex , collisionPoint);
        //moveScript.ConnectedBall(collision.rigidbody);
        moveScript.BallChridren(collision.transform);
        // ��������ٶȸ������壬�������ƶ�
        moveScript.Move(initialRelativeVelocity);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        edgeCollider = GetComponent<EdgeCollider2D>();
        points = edgeCollider.points;
        Gizmos.DrawSphere(transform.position+(Vector3)points[points.Length - 1], 1f);
    }
}