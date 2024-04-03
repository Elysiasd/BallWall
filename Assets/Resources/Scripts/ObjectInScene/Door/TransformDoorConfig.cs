using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "������")]
public class TransformDoorConfig : BaseWallConfig
{
    [Header("�����Ŵ��ͼ��ʱ��")]
    [Min(0)]public float TransformBreakTime;
    [Header("�ٶ���������")]
    [Range(0, 1)] public float SlowRate;
}
