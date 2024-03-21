using UnityEngine;

public class BrokenWall : MonoBehaviour
{
    public BrokenWallConfig brokenWallConfig;
    private Rigidbody2D rb;
    private Collider2D col;
    private Vector2 rbSpeed;
    private float limitedSpeed;
    private bool isBallIn;
    void Start()
    {
        rb = Ball.Instance.GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        rbSpeed = rb.velocity;
        limitedSpeed = brokenWallConfig.criticalVelocity;

        Ball.Instance.OnBallReachVelocity += () => col.isTrigger = true;
        Ball.Instance.OnBallReturnVelocity += () => col.isTrigger = false;
    }

    private void OnDestroy()
    {
        Ball.Instance.OnBallReachVelocity -= () => col.isTrigger = true;
        Ball.Instance.OnBallReturnVelocity -= () => col.isTrigger = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other == null) return;
        //TODO
        col.enabled = false; return;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Ball"))
        {
            isBallIn = false;
        }
        //TODO

    }
    // Update is called once per frame
    void Update()
    {

    }
}
