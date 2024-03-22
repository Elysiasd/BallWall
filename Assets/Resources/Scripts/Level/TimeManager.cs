using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
/// <summary>
/// 简单写个关卡内记录时间的东西，作为Manager的示例
/// </summary>
public class TimeManager : AbstractManagerInLevel
{
    private static TimeManager instance;
    public static TimeManager Instance
    {
        get
        {
            if (instance) return instance;
            else throw new System.Exception("未找到TimeManager单例，请检查场景或初始化顺序");
        }
    }
    public override int Order => 1;
    public override void Init()
    {
        instance = this;

        timer = 0;

        LevelManager.Instance.OnClear += () => Record();
    }
    public void OnDestroy()
    {
        LevelManager.Instance.OnClear -= () => Record();
    }

    public float timer { get; private set; }

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
    }
    private void Record()
    {
        try
        {
            if (float.Parse(Archive.GetData(LevelManager.Instance.LevelName)) > timer)
            {
                Archive.SetData(LevelManager.Instance.LevelName, timer.ToString("F2"));
            }
        }
        catch
        {
            Archive.SetData(LevelManager.Instance.LevelName, timer.ToString("F2"));
        }
    }
}
