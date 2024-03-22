using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��¼�ؿ��ռ���Ĺ�����
/// </summary>
public class CollectionManager : AbstractManagerInLevel
{
    private static CollectionManager instance;
    public static CollectionManager Instance
    {
        get
        {
            if (instance) return instance;
            else throw new System.Exception("δ�ҵ�CollectionManagerʵ�������鳡�����ʼ��˳��");
        }
    }

    public Dictionary<string, int> collections;
    public Dictionary<string, int> startCnt;

    public override int Order => 2;
    public override void Init()
    {
        instance = this;
        collections = new Dictionary<string, int>();
        startCnt = new Dictionary<string, int>();   
        Debug.Log(2);
    }

    public void Collect(string key)
    {
        if (!collections.ContainsKey(key)) { collections.Add(key, 1); }

        else { collections[key]++; }
    }

    public void StartCnt(string key)
    {
        if (!startCnt.ContainsKey(key)) { startCnt.Add(key,1); }

        else { startCnt[key]++; }
    }
}
