using UnityEngine;

public class BrokenWall : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;
    public BrokenWallConfig brokenWallConfig;
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
        AudioManager.Instance.PlayOneShot(audioClip);
        
        col.enabled = false; return;
    }


}
