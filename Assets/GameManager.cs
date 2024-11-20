using Cinemachine;
using Fusion;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public NetworkObject coinPrefab;
    public NetworkObject spidermanPrefab;
    public NetworkObject victoryTextPrefab;
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

    public void SpawnCoins(Fusion.NetworkRunner networkRunner)
    {
        foreach (CoinSpawnPoint coinSpawnPoint in FindObjectsOfType<CoinSpawnPoint>())
        {
            NetworkObject coinInstaniated = networkRunner.Spawn(coinPrefab, coinSpawnPoint.gameObject.transform.position, coinSpawnPoint.gameObject.transform.rotation);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    internal void SpawnVictoryText(NetworkRunner networkRunner)
    {
        Transform spawnPoint = FindObjectOfType<VictoryTextSpawnPoint>().transform;
        NetworkObject victoryTextInstantiated = networkRunner.Spawn(coinPrefab, spawnPoint.position, spawnPoint.rotation);

    }
}
