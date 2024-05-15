using System.Collections.Generic;
using UnityEngine;

public class BrokenWall : MonoBehaviour
{
    public BrokenWallConfig brokenWallConfig;
    public GameObject destroyVFX;
    private Collider2D col;
    private EdgeCollider2D edge;
    private Vector2 midPoint;
    void Start()
    {

        col = GetComponent<Collider2D>();
        edge = GetComponent<EdgeCollider2D>();
        midPoint = edge.points[edge.points.Length/2];
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
            Instantiate(destroyVFX, transform.position + (Vector3) midPoint, transform.rotation);
        }
        Destroy(gameObject);
    }

}
