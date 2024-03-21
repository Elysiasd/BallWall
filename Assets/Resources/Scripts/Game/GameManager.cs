using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private AbstractManagerInGame[] managers;
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        Archive.Load();

        Instance = this;
        InitManagers();
    }
    private void OnDestroy()
    {
        Archive.Save();
    }
    private void InitManagers()
    {
        //寻找场景中的Manager
        managers = FindObjectsByType<AbstractManagerInGame>(FindObjectsSortMode.None);
        //升序排列各Manager
        Array.Sort(managers, (a, b) => a.Order - b.Order);
        //初始化排序后的Manager
        foreach (AbstractManagerInGame manager in managers) manager.Init();
    }
}
