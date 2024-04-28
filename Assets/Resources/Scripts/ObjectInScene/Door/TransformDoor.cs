using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformDoor : MonoBehaviour
{
    private bool isOpen;
    public TransformDoorConfig Config;
    [SerializeField] private float breakTime;
    private float slowRate;
    private Transform thisTransform;
    protected Vector3 centerDistance;
    [SerializeField] private Transform connectedDoorTrans;
    private GameObject ball;
    private Rigidbody2D ballRb;

    private TransformDoor connectDoor;
    // Start is called before the first frame update
    private void Start()
    {
        thisTransform = GetComponent<Transform>();
        breakTime = Config.TransformBreakTime;
        slowRate = Config.SlowRate;
        isOpen = true;

        connectDoor = connectedDoorTrans.GetComponent<TransformDoor>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball") && isOpen)
        {
            centerDistance = new Vector3(collision.gameObject.transform.position.x - transform.position.x,
                collision.gameObject.transform.position.y - transform.position.y, collision.gameObject.transform.position.z);
            ball = collision.gameObject;
            ballRb = ball.GetComponent<Rigidbody2D>();
            Transforming(connectedDoorTrans);
            connectDoor.isOpen = false;
            StartCoroutine(RestartDoor());
        }
    }
    IEnumerator RestartDoor()
    {
        yield return new WaitForSeconds(breakTime);
        connectDoor.isOpen = true;
    }
    private void Transforming(Transform transform)
    {
        AdjustAxis();
        float angleDifference = transform.rotation.eulerAngles.z - thisTransform.rotation.eulerAngles.z;
        Vector3 newDistance = Quaternion.Euler(0, 0, angleDifference) * centerDistance;
        ball.transform.position = transform.position - newDistance;
        ballRb.velocity *= 1 - slowRate;
        ballRb.velocity = Quaternion.Euler(0, 0, angleDifference) * ballRb.velocity;
    }
    protected virtual void AdjustAxis() { }
}
