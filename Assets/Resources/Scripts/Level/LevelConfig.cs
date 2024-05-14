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

    public int Time => ChallengeManager.Instance.CurMode ==
        ChallengeManager.Mode.Time ? (int)(time * .8f) : time;
}
