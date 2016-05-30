using Photon;
using System;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

namespace UnityPhoton {
    public class NetworkController : PunBehaviour {
        public void CheckConnect() {
            if (PhotonNetwork.connected) {
                TryToJoinLobby();
            }
            else {
                PhotonNetwork.ConnectUsingSettings(NetworkConfig.GameVersion);
            }
        }

        private void TryToJoinLobby() {
            if (!PhotonNetwork.JoinLobby()) {
                throw new Exception("Failed to join lobby");
            }
        }

        public override void OnConnectedToPhoton() {
            base.OnConnectedToPhoton();
            Debug.Log("NetworkController.OnConnectedToPhoton()");
        }

        public override void OnConnectedToMaster() {
            base.OnConnectedToMaster();
            Debug.Log("NetworkController.OnConnectedToMaster()");
            TryToJoinLobby();
        }

        public override void OnFailedToConnectToPhoton(DisconnectCause cause) {
            base.OnFailedToConnectToPhoton(cause);
            Debug.Log("NetworkController.OnFailedToConnectToPhoton(" + cause.ToString() + ")");
        }

        public override void OnJoinedLobby() {
            base.OnJoinedLobby();
            Debug.Log("NetworkController.OnJoinedLobby()");
            SceneManager.LoadScene("Lobby");
        }
    }
}