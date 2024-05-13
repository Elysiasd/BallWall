using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "�ؿ�/�糡")]
public class WindFloorConfig : BaseFloorConfig
{
    [Header("�糡ʩ�����Ĵ�С")]
    [Min(0)] public float windForce;
    public AudioClip audioClip;
    [Header("�糡���ķ�������")]
    public Vector2 windVector;
    public float WindForce => windForce * Mathf.Log10
        (10 + 10 * (ShopManager.Instance.buffs[Archive.Wind] +
        int.Parse(PlayerPrefs.GetString(Archive.Wind, "0"))));
}
