using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : AbstractManagerInGame
{
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance) return instance;
            else throw new System.Exception("找不到UIManager单例，请检查场景或初始化顺序");
        }
    }
    public override int Order => 16;
    public override void Init()
    {
        instance = this;
    }

    [Header("UI")]
    [SerializeField] private Transform canvas;

    [SerializeField] private Target target;
    private Target _target;
    public Target Target => _target;
    public Target ActivateTarget()
    {
        _target = Instantiate(target.gameObject, canvas).GetComponent<Target>();
        return _target;
    }

    [SerializeField] private Timer timer;
    private Timer _timer;
    public Timer Timer => _timer;
    public Timer ActivateTimer()
    {
        _timer = Instantiate(timer, canvas).GetComponent<Timer>();
        return _timer;
    }

    [SerializeField] private Settlement settlement;
    private Settlement _settlement;
    public Settlement Settlement => _settlement;
    public Settlement ActivateSettlement()
    {
        _settlement = Instantiate(settlement, canvas).GetComponent<Settlement>();
        return _settlement;
    }

    [SerializeField] private LevelShop levelShop;
    private LevelShop _levelShop;
    public LevelShop LevelShop => _levelShop;
    public LevelShop ActivateLevelShop()
    {
        _levelShop = Instantiate(levelShop, canvas).GetComponent<LevelShop>();
        return _levelShop;
    }

    public void DisableAll()
    {
        if (_target != null) Destroy(_target.gameObject);
        if (_timer != null) Destroy(_timer.gameObject);
        if (_settlement != null) Destroy(_settlement.gameObject);
        if (_levelShop != null) Destroy(_levelShop.gameObject);

        _target = null;
        _timer = null;
        _settlement = null;
        _levelShop = null;
    }
    public void Continue() => StartCoroutine(ContinueCoroutine());
    private IEnumerator ContinueCoroutine()
    {
        yield return CurtainBehavior.Instance.ShowCoroutine();
        if (GameManager.Instance.LevelUp())
        {
            yield return CurtainBehavior.Instance.HideCoroutine();
            LevelManager.Instance.SwitchState(typeof(LevelStates.Target));
        }
        else
        {
            GameManager.Instance.SwitchState(typeof(GameStates.Main));
        }
    }
}
