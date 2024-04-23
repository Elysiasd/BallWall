using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settlement : MonoBehaviour
{
    [Header("设置")]
    [SerializeField] private float rollTime = 3;
    [SerializeField] private float pauseTime = 2;
    [Header("评价")]
    [SerializeField] private Sprite[] judgement;
    [SerializeField] private Image judgeImg;
    [Header("目标")]
    [SerializeField] private Text targetTime;
    [SerializeField] private Text targetInteract;
    [SerializeField] private Text targetCollection;
    [Header("实际")]
    [SerializeField] private Text finalTime;
    [SerializeField] private Text finalInteract;
    [SerializeField] private Text finalCollection;

    private float interval;
    private int num;

    private int judgeIdx = -1;

    [HideInInspector] public bool startCount;

    private LevelConfig config => LevelManager.Instance.Config;
    private void OnEnable()
    {
        targetTime.text = config.time.ToString();
        targetInteract.text = config.interact.ToString();
        targetCollection.text = config.collection.ToString();
        finalTime.text = finalInteract.text = finalCollection.text = "";

        startCount = false;
    }
    public void Settle(int time, int interact, int collection) =>
        StartCoroutine(SettleCoroutine(time, interact, collection));
    private IEnumerator SettleCoroutine(int time, int interact, int collection)
    {
        yield return new WaitUntil(() => startCount);
        LevelUp();

        yield return NumberRolling(config.time, time, finalTime, true);
        yield return NumberRolling(config.interact, interact, finalInteract);
        yield return NumberRolling(config.collection, collection, finalCollection);

        yield return new WaitForSeconds(pauseTime);
        LevelManager.Instance.SwitchState(typeof(LevelStates.Shop));
        gameObject.SetActive(false);
    }
    private IEnumerator NumberRolling(int target, int final, Text text, bool less = false)
    {
        interval = rollTime / 3 / (1 + final);
        num = 0;
        while (num < final)
        {
            text.text = num.ToString();
            yield return new WaitForSeconds(interval);
            num++;
        }
        text.text = final.ToString();
        if ((less ^ final > target) || final == target) LevelUp();
        yield return new WaitForSeconds(interval);
    }
    private void LevelUp() => judgeImg.sprite = judgement[++judgeIdx];
}
