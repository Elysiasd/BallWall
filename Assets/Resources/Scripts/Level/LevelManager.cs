using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : AbstractFSM
{
    private AbstractManagerInLevel[] managers;
    public static LevelManager Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
        InitManagers();

        states.Add(typeof(LevelStates.Target), new LevelStates.Target());
        states.Add(typeof(LevelStates.Run), new LevelStates.Run());
        states.Add(typeof(LevelStates.Pause), new LevelStates.Pause());
        states.Add(typeof(LevelStates.Settle), new LevelStates.Settle());
    }
    private void Start()
    {
        //调试用，应该放在Awake中
        SwitchState(typeof(LevelStates.Target));
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
    public LevelConfig Config => config;

    public string LevelName => config.levelName;

    public event Action OnClear;
    public void Clear()
    {
        OnClear?.Invoke();
        SwitchState(typeof(LevelStates.Settle));
    }
}
