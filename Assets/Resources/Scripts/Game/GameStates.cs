using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStates
{
    public class Main : AbstractStates
    {
        public override void OnEnter()
        {
            GameManager.Instance.CreateMainMenu();
        }
        public override void OnExit()
        {
            PlayerToBallManager.Instance.DisableInput();
            GameManager.Instance.DestroyCurMenu();
        }
    }
    public class Shop : AbstractStates
    {
        public override void OnEnter()
        {
            GameManager.Instance.CreateGameShop();
        }
        public override void OnExit()
        {
            PlayerToBallManager.Instance.DisableInput();
            GameManager.Instance.DestroyCurMenu();
        }
    }
    public class Level : AbstractStates
    {
        public override void OnEnter()
        {
            GameManager.Instance.LevelInit();
        }
    }
}
