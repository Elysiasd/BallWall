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
    private void OnEnable()
    {
        shrunk = false;
    }
    public void Show(float time, int interact, int collection)
        => StartCoroutine(ShowCoroutine(time, interact, collection));
    private IEnumerator ShowCoroutine(float time, int interact, int collection)
    {
        this.time.text = time.ToString();
        this.interact.text = interact.ToString();
        this.collection.text = collection.ToString();
        yield return new WaitUntil(() => shrunk);
        LevelManager.Instance.SwitchState(typeof(LevelStates.Run));
    }
}
