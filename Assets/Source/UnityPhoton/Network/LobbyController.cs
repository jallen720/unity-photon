using Photon;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

namespace UnityPhoton {
    public class LobbyController : PunBehaviour {
        private bool isJoiningRoom;

        private void Start() {
            isJoiningRoom = false;
        }

        public void FlagAsJoiningRoom() {
            isJoiningRoom = true;
        }

        public override void OnReceivedRoomListUpdate() {
            base.OnReceivedRoomListUpdate();
            Debug.Log("LobbyController.OnReceivedRoomListUpdate()");
        }

        public override void OnLobbyStatisticsUpdate() {
            base.OnLobbyStatisticsUpdate();
            Debug.Log("LobbyController.OnLobbyStatisticsUpdate()");
        }

        public override void OnLeftLobby() {
            base.OnLeftLobby();
            Debug.Log("LobbyController.OnLeftLobby()");
            CheckReturnToMainMenu();
        }

        private void CheckReturnToMainMenu() {
            if (!isJoiningRoom) {
                SceneManager.LoadScene("MainMenu");
            }
        }

        public override void OnCreatedRoom() {
            base.OnCreatedRoom();
            Debug.Log("OnCreatedRoom()");
        }

        public override void OnJoinedRoom() {
            base.OnJoinedRoom();
            Debug.Log("OnJoinedRoom()");
            SceneManager.LoadScene("Room");
        }

        public override void OnPhotonJoinRoomFailed(object[] codeAndMsg) {
            base.OnPhotonJoinRoomFailed(codeAndMsg);
            Debug.Log("OnPhotonJoinRoomFailed()");
            isJoiningRoom = false;
        }
    }
}