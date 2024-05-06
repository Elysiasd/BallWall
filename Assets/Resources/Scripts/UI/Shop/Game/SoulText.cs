using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulText : MonoBehaviour
{
    private TextMesh textMesh;
    private void Start()
    {
        textMesh = GetComponent<TextMesh>();
    }
    private void FixedUpdate()
    {
        textMesh.text = SoulManager.Instance.Soul.ToString();
    }
}
