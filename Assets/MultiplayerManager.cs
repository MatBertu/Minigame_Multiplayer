using Fusion;
using Fusion.Sockets;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MultiplayerManager : MonoBehaviour , INetworkRunnerCallbacks
{
    public NetworkRunner networkRunner;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        networkRunner = GetComponent<NetworkRunner>();
        StartGameArgs startGameArgs = new StartGameArgs();
        startGameArgs.GameMode = GameMode.Shared;
        startGameArgs.SessionName = "Prova";
        startGameArgs.PlayerCount = 10;
        networkRunner.StartGame(startGameArgs);
    
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnConnectedToServer(NetworkRunner runner)
    {
        Debug.Log("Sono connesso!");
        gameManager.SpawnSpiderman(networkRunner);

        Debug.Log("networkRunner.IsSharedModeMasterClient" + networkRunner.IsSharedModeMasterClient);
        if (networkRunner.IsSharedModeMasterClient)
        {
            Debug.Log("Spawno Coins!");
            gameManager.SpawnCoins(networkRunner);
            gameManager.SpawnVictoryText(networkRunner);
        }
    }

    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {

    }

    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {

    }

    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {

    }

    public void OnDisconnectedFromServer(NetworkRunner runner, NetDisconnectReason reason)
    {

    }

    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
    {

    }

    public void OnInput(NetworkRunner runner, NetworkInput input)
    {

    }

    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {

    }

    public void OnObjectEnterAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
    {

    }

    public void OnObjectExitAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
    {
    }

    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {

    }

    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {

    }

    public void OnReliableDataProgress(NetworkRunner runner, PlayerRef player, ReliableKey key, float progress)
    {
    }

    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ReliableKey key, ArraySegment<byte> data)
    {
    }

    public void OnSceneLoadDone(NetworkRunner runner)
    {
    }

    public void OnSceneLoadStart(NetworkRunner runner)
    {
    }

    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {
    }

    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
    }

    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {

    }
}
