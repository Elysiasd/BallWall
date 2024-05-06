using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopWallUI : MonoBehaviour
{
    private enum Type { Exit, Force, Slide, Bounce, Wind, Break }
    [SerializeField] private Type type;
    [SerializeField] private int cost = 10;
    private static bool collided;
    private void Start()
    {
        collided = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Ball") || collided) return;

        if (type == Type.Exit)
        {
            GameManager.Instance.SwitchState(typeof(GameStates.Main));
            Archive.Save();
            collided = true;
            return;
        }

        if (SoulManager.Instance.Afford(cost))
            Archive.SetData(type.ToString(),
            (int.Parse(Archive.GetData(type.ToString(), "0")) + 1).ToString());
    }
}
