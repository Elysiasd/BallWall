using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 珠壁掌管关卡外成长之魂的管理器
/// </summary>
public class SoulManager : AbstractManagerInGame
{
    private static SoulManager instance;
    public static SoulManager Instance
    {
        get
        {
            if (instance) return instance;
            else throw new System.Exception("未找到SoulManager单例，请检查场景或初始化顺序");
        }
    }
    public override int Order => 1;
    public override void Init()
    {
        instance = this;

        try
        {
            Soul = int.Parse(Archive.GetData(Archive.Soul));
        }
        catch
        {
            Soul = 0;
        }
    }

    private int soul;
    /// <summary>
    /// 芝士关卡外货币
    /// <br/>增加魂请使用<see cref="Attain(int)"/>
    /// <br/>消耗魂请使用<see cref="Afford(int)"/>
    /// </summary>
    public int Soul
    {
        get
        {
            return soul;
        }
        private set
        {
            Archive.SetData(Archive.Soul, value.ToString());
            soul = value;
        }
    }

    /// <summary>
    /// 增加魂的方法
    /// </summary>
    /// <param name="amount">获取魂的数额</param>
    public void Attain(int amount) => Soul += amount;

    public bool CanAfford(int consumption) => Soul >= consumption;
    public bool Afford(int consumption)
    {
        if (CanAfford(consumption))
        {
            Soul -= consumption;
            return true;
        }

        return false;
    }
}
