using Photon;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityPhoton {
    public class LobbyConnector : PunBehaviour {
        public override void OnConnectedToMaster() {
            base.OnConnectedToMaster();
            Debug.Log("LobbyConnector.OnConnectedToMaster()");
            TryToJoinLobby();
        }

        public void TryToJoinLobby() {
            if (!PhotonNetwork.JoinLobby()) {
                throw new Exception("Failed to join lobby");
            }
        }

        public override void OnJoinedLobby() {
            base.OnJoinedLobby();
            Debug.Log("LobbyConnector.OnJoinedLobby()");
            SceneManager.LoadScene("Lobby");
        }
    }
}