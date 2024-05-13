using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ǽ��/���ƻ�ǽ��")]
public class BrokenWallConfig : BaseWallConfig
{
    [Header("ǽ�������ٽ��ٶ�")]
    [Min(0)] public float criticalVelocity;
    [Header("ײǽ�����ٶ�")]
    [Range(0, 1)] public float speedSlowRate;
    public float SpeedSlowRate => speedSlowRate /
        (1 + (ShopManager.Instance.buffs[Archive.Break] +
        int.Parse(PlayerPrefs.GetString(Archive.Break, "0"))));
}
