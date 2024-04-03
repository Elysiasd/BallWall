using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "传送门")]
public class TransformDoorConfig : BaseWallConfig
{
    [Header("传送门传送间隔时间")]
    [Min(0)]public float TransformBreakTime;
    [Header("速度削减比例")]
    [Range(0, 1)] public float SlowRate;
}
