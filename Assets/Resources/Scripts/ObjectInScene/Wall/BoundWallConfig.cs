using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ç½±Ú/µ¯»ÉÇ½")]
public class BoundWallConfig : BaseWallConfig
{
    public float Bounce => bounce * Mathf.Log10
        (10 + 10 * (ShopManager.Instance.buffs[Archive.Bounce] +
        int.Parse(PlayerPrefs.GetString(Archive.Bounce, "0"))));
}
