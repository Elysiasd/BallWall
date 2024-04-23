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
}
