using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurtainBehavior : Common.MonoSingleton<CurtainBehavior>
{
    private Image img;

    [SerializeField] private float fadeTime;
    private float timer;
    private void Start()
    {
        img = GetComponent<Image>();
        timer = 0;
    }
    private IEnumerator Show()
    {
        StopCoroutine(Hide());
        img.enabled = true;
        while (timer < fadeTime)
        {
            img.color = Color.black * (timer / fadeTime);
            timer += Time.unscaledDeltaTime;
            yield return null;
        }
        timer = fadeTime;
        img.color = Color.black;
    }
    private IEnumerator Hide()
    {
        StopCoroutine(Show());
        while (timer > 0)
        {
            img.color = Color.black * (timer / fadeTime);
            timer -= Time.unscaledDeltaTime;
            yield return null;
        }
        img.enabled = false;
    }
}
