using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    [SerializeField] private Text time;
    [SerializeField] private Text interact;
    [SerializeField] private Text collection;

    [HideInInspector] public bool shrunk;
    public void Show(float time, int interact, int collection)
    {
        this.time.text = time.ToString();
        this.interact.text = interact.ToString();
        this.collection.text = collection.ToString();
    }
}
