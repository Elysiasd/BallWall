using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 各种Manager继承此类，将初始化顺序和内容分别写进<see cref="Order"/>和<see cref="Init"/>中
/// <br>不要把初始化的内容写在Awake里面，以免打乱初始化顺序</br>
/// </summary>
public abstract class AbstractManager : MonoBehaviour
{
    /// <summary>
    /// 指定该Manager在<see cref="LevelManager.InitManagers"/>中的初始化顺序，越大越靠后
    /// </summary>
    public abstract int Order { get; }
    /// <summary>
    /// Manager初始化方法，由<see cref="LevelManager.InitManagers"/>调用
    /// </summary>
    public abstract void Init();
}
