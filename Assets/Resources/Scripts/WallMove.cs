using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class WallMove : MonoBehaviour
{
    [SerializeField] List<Transform> startEndPoints;
    private Rigidbody2D rb;
    [SerializeField]private List<Vector2> points;
    private Vector2 targetPoint;
    private Vector2 direct;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {

        if (startEndPoints.Count != 2)
        {
            Debug.LogError("请添加起点和终点,或检测是否多加了点");
        }
        if (!GetComponent<Rigidbody2D>())
        {
            this.AddComponent<Rigidbody2D>();
        }
        points.Add((Vector2)startEndPoints[0].position);
        points.Add((Vector2)startEndPoints[1].position);
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        targetPoint = startEndPoints[0].position;
        direct = (targetPoint - (Vector2)transform.position) .normalized;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Vector2.Distance(transform.position, targetPoint) < 1f)
        {
            targetPoint = targetPoint == points[0] ? points[1] : points[0];
        }
        direct = (targetPoint - (Vector2)transform.position).normalized;
        rb.MovePosition(transform.position + (Vector3)direct * speed * Time.deltaTime);
        
    }
}
