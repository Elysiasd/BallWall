using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindFloor : MonoBehaviour
{
    [SerializeField] private WindFloorConfig config;
    private bool isBallIn;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            collision.GetComponent<Rigidbody2D>().AddForce(config.windVector, ForceMode2D.Force);
        }
    }
}
