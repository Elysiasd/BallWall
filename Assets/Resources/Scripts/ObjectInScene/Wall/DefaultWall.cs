using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultWall : MonoBehaviour
{
    [SerializeField] private BaseWallConfig config;
    private void Start()
    {
        GetComponent<Collider2D>().sharedMaterial.bounciness = config.Bounce;
    }
}
