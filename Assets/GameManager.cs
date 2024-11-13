using Cinemachine;
using Fusion;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public NetworkObject spidermanPrefab;
    public Transform spawnPoint;
    public CinemachineVirtualCamera playerFollowCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SpawnSpiderman(Fusion.NetworkRunner networkRunner)
    {

        NetworkObject spidermanInstantiated = networkRunner.Spawn(spidermanPrefab, spawnPoint.position, spawnPoint.rotation);
        playerFollowCamera.Follow = spidermanInstantiated.GetComponentInChildren<PlayerCameraRoot>().gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
