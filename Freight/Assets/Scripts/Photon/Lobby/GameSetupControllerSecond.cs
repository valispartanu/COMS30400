﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using Photon.Realtime;

public class GameSetupControllerSecond : MonoBehaviourPunCallbacks
{
    /*
     * All this script is doing in the end is creating the player object. The game is told to find this player object under a 
     * PhotonPrefabs folder and to look for the prefab named PhotonPlayer.
     * Everything is setting the starting position and rotation values.
     * */
    void Start()
    {
        // https://forum.photonengine.com/discussion/7805/received-onserialization-for-view-id-xxxx-we-have-no-such-photon-view
        Invoke(nameof(SpawnPlayers), 3f);
    }

    void SpawnPlayers()
    {
        if (PhotonNetwork.IsMasterClient)
            photonView.RPC(nameof(CreatePlayer), RpcTarget.AllBufferedViaServer);
    }

    [PunRPC]
    private void CreatePlayer()
    {
        int z = Random.Range(294, 303);
        PhotonNetwork.Instantiate("PhotonPrefabs/PhotonPlayerPruna2", new Vector3(255, 8, z), Quaternion.identity);
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        if (newMasterClient != null)
            PhotonNetwork.LoadLevel(0);
    }
}