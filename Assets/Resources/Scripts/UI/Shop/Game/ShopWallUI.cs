using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopWallUI : MonoBehaviour
{
    private enum Type { Exit,Force,Slide,Bounce,Wind,Break}
    [SerializeField]private Type type;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.collider.CompareTag("Ball")) return;

        switch (type)
        {
            case Type.Exit:
                GameManager.Instance.SwitchState(typeof(GameStates.Main));
                break;
            case Type.Force:
                break;
            case Type.Slide:
                break;
            case Type.Bounce:
                break;
            case Type.Wind:
                break;
        }
    }
}
