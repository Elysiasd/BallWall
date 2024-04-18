using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ç½±Ú/¿ÉÆÆ»µÇ½±Ú")]
public class BrokenWallConfig : BaseWallConfig
{
    [Header("Ç½±ÚÆÆËéÁÙ½çËÙ¶È")]
    [Min(0)]public float criticalVelocity;
    [Header("×²Ç½Ï÷¼õËÙ¶È")]
    [Range(0,1)]public float speedSlowRate;
}
