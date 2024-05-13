using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "墙壁/滑墙")]
public class SlideWallConfig : BaseWallConfig
{
    [Header("滑墙最终保留速度的比例")]
    public float finalSpeedRate;
    [Header("滑行时的音频")]
    public AudioClip audioClip1;
    [Header("滑出的音频")]
    public AudioClip audioClip2;
    public float FinalSpeedRate => finalSpeedRate * Mathf.Log10
        (10 + 10 * (ShopManager.Instance.buffs[Archive.Slide] +
        int.Parse(PlayerPrefs.GetString(Archive.Slide, "0"))));
}
