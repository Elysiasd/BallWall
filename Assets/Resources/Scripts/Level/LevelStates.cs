using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStates
{
    public class Target : AbstractStates
    {
        public override void OnEnter()
        {
            LevelManager.Instance.ShowTarget();
        }
    }
    public class Run : AbstractStates
    {
        public override void OnEnter()
        {
            TimeManager.Instance.Begin();
            _ = UIManager.Instance.ActivateTimer();

            PlayerToBallManager.Instance.EnableInput();
        }
    }
    public class Pause : AbstractStates
    {

    }
    public class Settle : AbstractStates
    {

    }
}
