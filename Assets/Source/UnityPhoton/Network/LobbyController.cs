using Photon;
using UnityUtils.EventUtils;
using Debug = UnityEngine.Debug;

namespace UnityPhoton {
    public class LobbyController : PunBehaviour {
        private Event joinedLobbyEvent;

        public Event JoinedLobbyEvent {
            get {
                return joinedLobbyEvent ?? LoadJoinedLobbyEvent();
            }
        }

        private Event LoadJoinedLobbyEvent() {
            return joinedLobbyEvent = new Event();
        }

        public void CheckJoinLobby() {
            if (PhotonNetwork.insideLobby) {
                JoinedLobbyEvent.Trigger();
            }
            else {
                PhotonNetwork.JoinLobby();
            }
        }

        public override void OnJoinedLobby() {
            base.OnJoinedLobby();
            Debug.Log("LobbyController.OnJoinedLobby()");
            JoinedLobbyEvent.Trigger();
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
        }
    }
}