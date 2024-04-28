using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : AbstractFSM
{
    private AbstractManagerInGame[] managers;
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        Archive.Load();

        Instance = this;
        InitManagers();
        InitStates();
    }
    private void InitStates()
    {
        states.Add(typeof(GameStates.Main), new GameStates.Main());
        states.Add(typeof(GameStates.Shop), new GameStates.Shop());
        states.Add(typeof(GameStates.Level), new GameStates.Level());

        SwitchState(debug ? typeof(GameStates.Level) : typeof(GameStates.Main));
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

    [SerializeField] private bool debug = true;

    [SerializeField] private GameObject[] levels;
    [SerializeField] private GameObject mainMenu;

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

    private GameObject menu;
    public void CreateMainMenu() => menu =
        Instantiate(mainMenu, Vector3.zero, Quaternion.identity);
    public void DestroyMainMenu() => Destroy(menu, CurtainBehavior.Instance.FadeTime);
}
