using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

/// <summary>
/// 基本的收集品的属性和函数
/// </summary>
public abstract class BaseCollection : MonoBehaviour
{
    [SerializeField] protected AudioClip clip;
    [SerializeField] private float collectTime = 1f;
    protected abstract string colName { get; }
    private CollectionManager collectionManager;

    private Vector3 origin;

    protected virtual void Start()
    {
        collectionManager = CollectionManager.Instance;
        collectionManager.StartCnt(colName);

        origin = transform.position;
    }
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball")) { StartCoroutine(Collect()); }
    }
    private IEnumerator Collect()
    {
        float timer = 0;
        while (timer < collectTime)
        {
            transform.position = Vector3.Lerp(origin,
                Ball.Instance.transform.position, timer / collectTime);
            timer += Time.deltaTime;
            yield return null;
        }
        collectionManager.Collect(colName);
        AudioManager.Instance.PlayOneShot(clip);
        Destroy(gameObject);
    }
}