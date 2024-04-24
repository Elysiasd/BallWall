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
    [SerializeField] private Target target;
    public Target Target => target;
    public Target ActivateTarget()
    {
        target.gameObject.SetActive(true);
        return target;
    }

    [SerializeField] private Timer timer;
    public Timer Timer => timer;
    public Timer ActivateTimer()
    {
        timer.gameObject.SetActive(true);
        return timer;
    }

    [SerializeField] private Settlement settlement;
    public Settlement Settlement => settlement;
    public Settlement ActivateSettlement()
    {
        settlement.gameObject.SetActive(true);
        return settlement;
    }

    [SerializeField] private LevelShop levelShop;
    public LevelShop LevelShop => levelShop;
    public LevelShop ActivateLevelShop()
    {
        levelShop.gameObject.SetActive(true);
        return levelShop;
    }

    public void DisableAll()
    {
        target.gameObject.SetActive(false);
        timer.gameObject.SetActive(false);
        settlement.gameObject.SetActive(false);
        levelShop.gameObject.SetActive(false);
    }

    [Header("配置")]
    [SerializeField] private float fadeTime = 1;

    public void Continue() => StartCoroutine(ContinueCoroutine());
    public IEnumerator ContinueCoroutine()
    {
        yield return CurtainBehavior.Instance.ShowCoroutine();
        if (GameManager.Instance.LevelUp())
        {
            yield return CurtainBehavior.Instance.HideCoroutine();
            LevelManager.Instance.SwitchState(typeof(LevelStates.Target));
        }
    }
}
