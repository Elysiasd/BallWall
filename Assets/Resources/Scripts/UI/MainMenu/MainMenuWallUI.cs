using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuWallUI : MonoBehaviour
{
    private enum Type { Level, Shop, Exit }
    [SerializeField] private Type type;

    private static bool collided;

    private void Start()
    {
        collided = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Ball") || collided) return;
        collided = true;

        switch (type)
        {
            case Type.Level:
                GameManager.Instance.SwitchState(typeof(GameStates.Level));
                break;
            case Type.Shop:
                GameManager.Instance.SwitchState(typeof(GameStates.Shop));
                break;
            case Type.Exit:
                StartCoroutine(Exit());
                break;
        }
    }
    private IEnumerator Exit()
    {
        yield return CurtainBehavior.Instance.ShowCoroutine();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
    }
}
