using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
/// <summary>
/// 简单写个关卡内记录时间的东西，作为Manager的示例
/// </summary>
public class TimeManager : AbstractManagerInGame
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
    public override int Order => 2;
    public override void Init()
    {
        instance = this;

        timer = 0;
    }

    private bool pause;
    public float timer { get; private set; }

    private void FixedUpdate()
    {
        if (!pause) timer += Time.fixedDeltaTime;
    }
    public void Pause() => pause = true;
    public void Resume() => pause = false;
    public void Begin()
    {
        timer = 0;
        pause = false;
    }
    public void Record()
    {
        if (float.Parse(Archive.GetData(LevelManager.Instance.LevelName, "0")) > timer)
        {
            Archive.SetData(LevelManager.Instance.LevelName, timer.ToString("F2"));
        }
    }
}
