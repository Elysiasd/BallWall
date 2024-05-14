using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopWallUI : MonoBehaviour
{
    private enum Type { Exit, Force, Slide, Bounce, Wind, Break }
    [SerializeField] private Type type;
    [SerializeField] private int cost = 10;
    [SerializeField] private bool showSoul = true;
    private static bool collided;
    private int Cost => cost * (1 + int.Parse(Archive.GetData(type.ToString(), "0")));
    private void Start()
    {
        collided = false;
        if (showSoul) GetComponentInChildren<TextMesh>().text = type + " " + Cost;
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

        if (SoulManager.Instance.Afford(Cost))
            Archive.SetData(type.ToString(),
            (int.Parse(Archive.GetData(type.ToString(), "0")) + 1).ToString());
    }
}
