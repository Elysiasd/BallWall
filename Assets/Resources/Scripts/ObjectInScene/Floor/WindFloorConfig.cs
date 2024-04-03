using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "地块/风场")]
public class WindFloorConfig : BaseFloorConfig
{
    [Header("风场施加力的大小")]
    [Min(0)]public float windForce;
    [Header("风场力的方向向量")]
    public Vector2 windVector;
}
