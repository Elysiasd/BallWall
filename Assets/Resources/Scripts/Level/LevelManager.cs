using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private AbstractManagerInLevel[] managers;
    public static LevelManager Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
        InitManagers();
    }
    private void Start()
    {
        //调试时，实际应放在Awake里面
        UIManager.Instance.ActivateTarget().Show(config.time, config.interact, config.collection);
    }
    private void InitManagers()
    {
        //寻找场景中的Manager
        managers = FindObjectsByType<AbstractManagerInLevel>(FindObjectsSortMode.None);
        //升序排列各Manager
        Array.Sort(managers, (a, b) => a.Order - b.Order);
        //初始化排序后的Manager
        foreach (AbstractManagerInLevel manager in managers) manager.Init();
    }

    [SerializeField] private LevelConfig config;

    public string LevelName => config?.levelName ?? "芝士关卡名称";

    public event Action OnClear;
    public void Clear() => OnClear?.Invoke();
}
