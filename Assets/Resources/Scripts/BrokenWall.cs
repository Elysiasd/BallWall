using UnityEngine;

public class BrokenWall : MonoBehaviour
{
    public BrokenWallConfig brokenWallConfig;
    private Rigidbody2D rb;
    private Vector2 rbSpeed;
    private float limitedSpeed;
    private bool isBallIn;
    void Start()
    {
        rb = Ball.Instance.GetComponent<Rigidbody2D>();
        rbSpeed = rb.velocity;
        limitedSpeed = brokenWallConfig.criticalVelocity;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("123");
        if (other ==  null) return;
        if (other.gameObject.CompareTag("Ball"))
        {
           isBallIn = true;
           if(rbSpeed.sqrMagnitude > limitedSpeed* limitedSpeed)
            {
                foreach(Collider2D co in this.GetComponents<Collider2D>())
                {
                    Debug.Log(co);
                    if (!co.isTrigger) 
                    {
                        Debug.Log("123");
                        co.enabled = false;
                    }
                        
                }
                //TODO;∂Øª≠and“Ù–ß
            }
        }
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
