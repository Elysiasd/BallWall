using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurtainBehavior : Common.MonoSingleton<CurtainBehavior>
{
    private Image img;

    [SerializeField] private float fadeTime;
    public float FadeTime => fadeTime;
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
            timer += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
        timer = fadeTime;
        img.color = Color.black;
    }
    public void Hide()
    {
        StopAllCoroutines();
        StartCoroutine(HideCoroutine());
    }
    public IEnumerator HideCoroutine()
    {
        StopCoroutine(ShowCoroutine());
        while (timer > 0)
        {
            img.color = Color.black * (timer / fadeTime);
            timer -= Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
        img.enabled = false;
    }
}
