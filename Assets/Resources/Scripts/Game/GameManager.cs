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
        //寻找子物体中的Manager
        managers = GetComponentsInChildren<AbstractManagerInGame>();
        //升序排列各Manager
        Array.Sort(managers, (a, b) => a.Order - b.Order);
        //初始化排序后的Manager
        foreach (AbstractManagerInGame manager in managers) manager.Init();
    }

    private void Start()
    {
        //应当由开始游戏按钮调用
        LevelInit();
    }

    [SerializeField] private GameObject[] levels;

    private GameObject curLevel;
    private int levelIdx;
    public bool LevelUp()
    {
        Destroy(curLevel);
        levelIdx++;
        if (levelIdx == levels.Length)
        {
            return false;
        }
        else
        {
            curLevel = Instantiate(levels[levelIdx], Vector3.zero, Quaternion.identity);
            return true;
        }
    }
    public void LevelInit() => StartCoroutine(LevelInitCoroutine());
    private IEnumerator LevelInitCoroutine()
    {
        levelIdx = 0;
        yield return CurtainBehavior.Instance.ShowCoroutine();
        curLevel = Instantiate(levels[levelIdx], Vector3.zero, Quaternion.identity);
        yield return CurtainBehavior.Instance.HideCoroutine();
        LevelManager.Instance.SwitchState(typeof(LevelStates.Target));
    }
}
