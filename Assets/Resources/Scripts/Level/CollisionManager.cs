using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class CollisionManager : AbstractManagerInLevel
{
    private static CollisionManager instance;
    public static CollisionManager Instance
    {
        get
        {
            if (instance) return instance;
            else throw new System.Exception("未找到CollisionManager单例，请检查场景或初始化顺序");
        }
    }

    public int CollisionCnt {  get; private set; }
    public override int Order => 4;

    public override void Init()
    {
        instance = this;
        CollisionCnt = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        Ball.Instance.OnBallCollision += () => CollisionCnt++;
    }

    private void OnDestroy()
    {
        Ball.Instance.OnBallCollision -= () => CollisionCnt++;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
