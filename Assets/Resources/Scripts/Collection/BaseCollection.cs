using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 基本的收集品的属性和函数
/// </summary>
public abstract class BaseCollection : MonoBehaviour
{
    [SerializeField]protected AudioClip clip;
    protected abstract string colName { get; }
    private CollectionManager collectionManager;

    protected virtual void Start()
    {
        collectionManager = CollectionManager.Instance;
        collectionManager.StartCnt(colName);
    }
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            collectionManager.Collect(colName);
            AudioManager.Instance.PlayOneShot(clip);
            Destroy(gameObject);
            //TODO

        }
    }


}
