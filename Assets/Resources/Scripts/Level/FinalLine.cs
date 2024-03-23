using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class FinalLine : MonoBehaviour
{
    private BoxCollider2D col;

    private void Start()
    {
        col = GetComponent<BoxCollider2D>();
        col.isTrigger = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            LevelManager.Instance?.Clear();
            col.enabled = false;
        }
    }
}
