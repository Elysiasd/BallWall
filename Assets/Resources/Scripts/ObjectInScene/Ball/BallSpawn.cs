using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawn : MonoBehaviour
{
    [SerializeField] private List<GameObject> spawnList;
    public List<GameObject> SpawnList => spawnList;
    private GameObject spawnPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Born(0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Born(int index)
    {
        CameraManager.Instance.VirtualCamera.Follow = Instantiate(SpawnList[index],transform).transform;
    }

    
}
