using UnityEngine;

public class BrokenWall : MonoBehaviour
{
    public BrokenWallConfig brokenWallConfig;
    public GameObject destroyVFX;
    private Collider2D col;
    void Start()
    {

        col = GetComponent<Collider2D>();

        Ball.Instance.OnBallReachVelocity += IsTrigger;
        Ball.Instance.OnBallReturnVelocity += IsCollider;
    }
    private void IsTrigger() => col.isTrigger = true;

    private void IsCollider() => col.isTrigger = false;

    private void OnDestroy()
    {
        Ball.Instance.OnBallReachVelocity -= IsTrigger;
        Ball.Instance.OnBallReturnVelocity -= IsCollider;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other == null) return;
        //TODO
        if (other.gameObject.CompareTag("Ball"))
        {
            DestroyObject();
        }
        
        
        return;
    }

    //销毁墙体并且释放粒子效果
    private void DestroyObject()
    {
        AudioManager.Instance.PlayOneShot(brokenWallConfig.audioClip);
        col.enabled = false;
        if (destroyVFX != null)
        {
            Instantiate(destroyVFX, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }

}
