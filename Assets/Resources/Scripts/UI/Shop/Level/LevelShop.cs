using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelShop : MonoBehaviour
{
    [Header("文本框")]
    [SerializeField] private Text money;
    [SerializeField] private Text challengeName;
    [SerializeField] private Text challengeDescription;
    [Header("按钮")]
    [SerializeField] private Button[] goodsBtn;
    [SerializeField] private Button challengeBtn;

    private string[] goods;
    [SerializeField] private int[] costs;
    public void OnEnable()
    {
        InitBtns();
        InitChallenge();
    }
    public void FixedUpdate()
    {
        money.text = ShopManager.Instance.Money.ToString();
    }

    private int infoIdx;
    private void InitChallenge()
    {
        infoIdx = UnityEngine.Random.Range(0, ChallengeManager.Instance.Infos.Length);
        challengeName.text = ChallengeManager.Instance.Infos[infoIdx].mode.ToString();
        challengeDescription.text = ChallengeManager.Instance.Infos[infoIdx].description;
        challengeBtn.onClick.AddListener(() =>
            ChallengeManager.Instance.Infos[infoIdx].Execute(challengeBtn));
    }
    private void InitBtns()
    {
        goods = new string[goodsBtn.Length];
        for (int i = 0; i < goodsBtn.Length; i++)
        {
            goods[i] = Archive.Buffs[UnityEngine.Random.Range(0, Archive.Buffs.Length)];
            FixBtn(i);//不知道为什么直接写就会溢出
        }
    }
    private void FixBtn(int idx)
    {
        goodsBtn[idx].onClick.AddListener(() =>
        {
            if (ShopManager.Instance.Afford(costs[idx]))
            {
                ShopManager.Instance.buffs[goods[idx]]++;
                goodsBtn[idx].interactable = false;
            }
        });
        goodsBtn[idx].GetComponentInChildren<Text>().text
            = goods[idx] + "\n" + costs[idx].ToString();
    }

    public void Continue() => UIManager.Instance.Continue();
    public void Back() => GameManager.Instance.SwitchState(typeof(GameStates.Main));
}
