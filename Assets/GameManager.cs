using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject spidermanPrefab;
    public Transform spawnPoint;
    public CinemachineVirtualCamera playerFollowCamera;
    // Start is called before the first frame update
    void Start()
    {
        SpawnSpiderman();
    }

    private void SpawnSpiderman()
    {
        GameObject spidermanInstantiated = Instantiate(spidermanPrefab, spawnPoint.position, spawnPoint.rotation);
        playerFollowCamera.Follow = spidermanInstantiated.GetComponentInChildren<PlayerCameraRoot>().gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
