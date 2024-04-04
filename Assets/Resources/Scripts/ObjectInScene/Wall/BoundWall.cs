using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundWall : MonoBehaviour
{
    [SerializeField] BoundWallConfig config;
    private Rigidbody2D ballRb; 

    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            ballRb = collision.GetComponent<Rigidbody2D>();
            ballRb.velocity = -config.bounce * ballRb.velocity;
        }
    }
   
}
