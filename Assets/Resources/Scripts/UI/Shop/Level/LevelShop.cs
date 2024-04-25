using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelShop : MonoBehaviour
{
    [Header("文本框")]
    [SerializeField] private Text money;
    public void OnEnable()
    {
        money.text = ShopManager.Instance.Money.ToString();
    }

    public void Continue() => UIManager.Instance.Continue();
}
