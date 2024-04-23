using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text text;
    private void FixedUpdate()
    {
        text.text = TimeManager.Instance.Timer.ToString("F2");
    }
}
