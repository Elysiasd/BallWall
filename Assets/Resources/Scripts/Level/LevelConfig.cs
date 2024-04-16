using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Level/Config")]
public class LevelConfig : ScriptableObject
{
    [Header("关卡名称")]
    public string levelName;
    [Header("评级标准")]
    public int time;
    public int interact;
    public int collection;
}
