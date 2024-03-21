using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
/// <summary>
/// 简单写个关卡内记录时间的东西，作为Manager的示例
/// </summary>
public class TimeManager : AbstractManagerInLevel
{
    private TimeManager instance;
    public TimeManager Instance
    {
        get
        {
            if (instance) return instance;
            else throw new System.Exception("未找到TimeManager实例，请检查场景或初始化顺序");
        }
    }

    public float timer { get; private set; }

    public override int Order => 1;
    public override void Init()
    {
        instance = this;
        timer = 0;
        Debug.Log(1);
    }

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
    }
}
