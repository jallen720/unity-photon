using Photon;
using UnityUtils.EventUtils;
using Debug = UnityEngine.Debug;

namespace UnityPhoton {
    public class LobbyController : PunBehaviour {
        public readonly Event ReceivedRoomListEvent = new Event();
        public readonly Event LeftLobbyEvent = new Event();

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
            LeftLobbyEvent.Trigger();
        }

        public override void OnCreatedRoom() {
            base.OnCreatedRoom();
            Debug.Log("OnCreatedRoom()");
        }

        public override void OnJoinedRoom() {
            base.OnJoinedRoom();
            Debug.Log("OnJoinedRoom()");
        }
    }
}