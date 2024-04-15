using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawn : MonoBehaviour
{
    [SerializeField] private List<GameObject> spawnList;
    public List<GameObject> SpawnList => spawnList;
    private GameObject ball;
     
    // Start is called before the first frame update
    void Awake()
    {
        Born(0);
        
    }

    private void Start()
    {
        CameraManager.Instance.VirtualCamera.Follow = ball.transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Born(int index)
    {
        ball = Instantiate(SpawnList[index],transform);
    }

    
}
