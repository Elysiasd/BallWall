using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
/// <summary>
/// ��д���ؿ��ڼ�¼ʱ��Ķ�������ΪManager��ʾ��
/// </summary>
public class TimeManager : AbstractManagerInGame
{
    private static TimeManager instance;
    public static TimeManager Instance
    {
        get
        {
            if (instance) return instance;
            else throw new System.Exception("δ�ҵ�TimeManager���������鳡�����ʼ��˳��");
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
        LevelManager.Instance.OnClear += Pause;

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
