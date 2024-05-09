using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ǽ��/��ǽ")]
public class SlideWallConfig : BaseWallConfig
{
    [Header("��ǽ���ձ����ٶȵı���")]
    public float finalSpeedRate;
    public float FinalSpeedRate => finalSpeedRate * Mathf.Log10
        (10 + 10 * (ShopManager.Instance.buffs[Archive.Slide] +
        int.Parse(PlayerPrefs.GetString(Archive.Slide, "0"))));
}
