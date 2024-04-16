using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Level/Config")]
public class LevelConfig : ScriptableObject
{
    [Header("�ؿ�����")]
    public string levelName;
    [Header("������׼")]
    public int time;
    public int interact;
    public int collection;
}
