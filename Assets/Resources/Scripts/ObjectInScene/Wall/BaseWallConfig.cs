using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
[CreateAssetMenu(menuName = "ǽ��/��ͨ�߽�ǽ��")]
public class BaseWallConfig : ScriptableObject
{
    [Header("�߽絯��")]
    [Range(0,1)]public float bounce;
}
