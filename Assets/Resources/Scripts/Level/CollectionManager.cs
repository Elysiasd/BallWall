using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 记录关卡收集物的管理器
/// </summary>
public class CollectionManager : AbstractManagerInLevel
{
    private static CollectionManager instance;
    public static CollectionManager Instance
    {
        get
        {
            if (instance) return instance;
            else throw new System.Exception("未找到CollectionManager实例，请检查场景或初始化顺序");
        }
    }

    private Dictionary<string, int> collections;
    private Dictionary<string, int> startCnt;

    public override int Order => 2;
    public override void Init()
    {
        instance = this;
        collections = new Dictionary<string, int>();
        startCnt = new Dictionary<string, int>();
    }

    public void Collect(string key)
    {
        collections[key]++;
    }
    public int CollectionNum(string key)
    {
        return collections[key];
    }
    public void StartCnt(string key)
    {
        if (!startCnt.ContainsKey(key))
        {
            startCnt.Add(key, 1);
            collections.Add(key, 0);
        }
        else { startCnt[key]++; }
    }
}
