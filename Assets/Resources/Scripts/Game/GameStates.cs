using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStates
{
    public class Main : AbstractStates
    {
        private float timer;
        public override void OnEnter()
        {
            GameManager.Instance.CreateMainMenu();
            //回头改了Manager再加回来
            //
            timer = 0;
        }
        public override void OnFixedUpdate()
        {PlayerToBallManager.Instance.EnableInput();
            timer += Time.fixedDeltaTime;
            if (timer < 1) return;
            //GameManager.Instance.SwitchState(typeof(Level));
        }
        public override void OnExit()
        {
            GameManager.Instance.DestroyMainMenu();
            //PlayerToBallManager.Instance.DisableInput();
        }
    }
    public class Shop : AbstractStates
    {
    }
    public class Level : AbstractStates
    {
        public override void OnEnter()
        {
            GameManager.Instance.LevelInit();
        }
    }
}
