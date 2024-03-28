using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : AbstractManagerInLevel
{
    private static ShopManager instance;
    public static ShopManager Instance
    {
        get
        {
            if (instance) return instance;
            else throw new System.Exception("未找到ShopManager单例，请检查场景或初始化顺序");
        }
    }
    public override int Order => 1;
    public override void Init()
    {
        instance = this;

        Money = 0;
    }

    /// <summary>
    /// 芝士关卡内货币
    /// <br/>增加钱请使用<see cref="Attain(int)"/>
    /// <br/>消耗钱请使用<see cref="Afford(int)"/>
    /// </summary>
    public int Money { get; private set; }

    /// <summary>
    /// 增加钱的方法
    /// </summary>
    /// <param name="amount">获取钱的数额</param>
    public void Attain(int amount) => Money += amount;

    public bool CanAfford(int consumption) => Money >= consumption;
    public bool Afford(int consumption)
    {
        if (CanAfford(consumption))
        {
            Money -= consumption;
            return true;
        }

        return false;
    }
}
