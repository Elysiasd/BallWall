using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class LevelStates
{
    public class Target : AbstractStates
    {
        public override void OnEnter()
        {
            UIManager.Instance.ActivateTarget().Show
                (LevelManager.Instance.Config.time,
                LevelManager.Instance.Config.interact,
                LevelManager.Instance.Config.collection);
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
        public override void OnEnter()
        {
            //停止对球的操作
            PlayerToBallManager.Instance.DisableInput();
            //呼出结算界面
            UIManager.Instance.ActivateSettlement().Settle
                (Mathf.FloorToInt(TimeManager.Instance.Timer),
                CollisionManager.Instance.CollisionCnt,
                CollectionManager.Instance.CollectionNum(CollectionName.Money));
        }
    }
}
