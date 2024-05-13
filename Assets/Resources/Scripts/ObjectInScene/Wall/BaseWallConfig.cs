using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
[CreateAssetMenu(menuName = "Ç½±Ú/ÆÕÍ¨±ß½çÇ½±Ú")]
public class BaseWallConfig : ScriptableObject
{
    [Header("±ß½çµ¯ÐÔ")]
    [Range(0, 1)] public float bounce;
    public float Bounce => Mathf.Lerp(1, bounce, 1 /
        (ShopManager.Instance.buffs[Archive.Bounce] +
        int.Parse(PlayerPrefs.GetString(Archive.Bounce, "0"))));
}
