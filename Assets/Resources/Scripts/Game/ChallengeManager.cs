using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChallengeManager : AbstractManagerInGame
{
    private static ChallengeManager instance;
    public static ChallengeManager Instance
    {
        get
        {
            if (instance) return instance;
            else throw new System.Exception("未找到ChallengeManager实例，请检查场景或初始化顺序。");
        }
    }
    public override int Order => 32;
    public override void Init()
    {
        instance = this;
        ResetChallenge();
    }
    public enum Mode { Time, Interact, Count }
    public Mode CurMode { get; private set; }
    public void ResetChallenge() => CurMode = Mode.Count;
    [Serializable]
    public struct Info
    {
        public Mode mode;
        public string description;
        public int cost;
        public int bonus;
        public readonly void Execute(Button btn)
        {
            if (ShopManager.Instance.Afford(cost))
            {
                btn.interactable = false;
                instance.CurMode = mode;
                instance.CurInfo = this;
            }
        }
    }
    [SerializeField] private Info[] infos;
    public Info[] Infos => infos;
    public Info CurInfo { get; private set; }
}
