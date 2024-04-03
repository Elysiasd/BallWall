using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "�ؿ�/�糡")]
public class WindFloorConfig : BaseFloorConfig
{
    [Header("�糡ʩ�����Ĵ�С")]
    [Min(0)]public float windForce;
    [Header("�糡���ķ�������")]
    public Vector2 windVector;
}
