using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurtainBehavior : Common.MonoSingleton<CurtainBehavior>
{
    private Image img;

    [SerializeField] private float fadeTime;
    private float timer;
    protected override void Awake()
    {
        base.Awake();
        img = GetComponent<Image>();
        timer = 0;
    }

    public void Show() => StartCoroutine(ShowCoroutine());
    public IEnumerator ShowCoroutine()
    {
        StopCoroutine(HideCoroutine());
        img.enabled = true;
        while (timer < fadeTime)
        {
            img.color = Color.black * (timer / fadeTime);
            timer += Time.deltaTime;
            yield return null;
        }
        timer = fadeTime;
        img.color = Color.black;
    }
    public void Hide() => StartCoroutine(HideCoroutine());
    public IEnumerator HideCoroutine()
    {
        StopCoroutine(ShowCoroutine());
        while (timer > 0)
        {
            img.color = Color.black * (timer / fadeTime);
            timer -= Time.deltaTime;
            yield return null;
        }
        img.enabled = false;
    }
}
