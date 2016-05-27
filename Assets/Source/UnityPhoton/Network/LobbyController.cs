using Photon;
using UnityUtils.EventUtils;
using Debug = UnityEngine.Debug;

namespace UnityPhoton {
    public class LobbyController : PunBehaviour {
        private Event receivedRoomListEvent;

        public Event ReceivedRoomListEvent {
            get {
                return receivedRoomListEvent ?? LoadReceivedRoomListEvent();
            }
        }

        private Event LoadReceivedRoomListEvent() {
            return receivedRoomListEvent = new Event();
        }

        public void CheckJoinLobby() {
            if (PhotonNetwork.insideLobby) {
                ReceivedRoomListEvent.Trigger();
            }
            else {
                PhotonNetwork.JoinLobby();
            }
        }

        public override void OnJoinedLobby() {
            base.OnJoinedLobby();
            Debug.Log("LobbyController.OnJoinedLobby()");
        }

        public override void OnReceivedRoomListUpdate() {
            base.OnReceivedRoomListUpdate();
            Debug.Log("LobbyController.OnReceivedRoomListUpdate()");
            ReceivedRoomListEvent.Trigger();
        }

        public override void OnLobbyStatisticsUpdate() {
            base.OnLobbyStatisticsUpdate();
            Debug.Log("LobbyController.OnLobbyStatisticsUpdate()");
        }

        public override void OnLeftLobby() {
            base.OnLeftLobby();
            Debug.Log("LobbyController.OnLeftLobby()");
        }
    }
}