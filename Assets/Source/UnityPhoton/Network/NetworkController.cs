using Photon;
using UnityUtils.EventUtils;
using Debug = UnityEngine.Debug;

namespace UnityPhoton {
    public class NetworkController : PunBehaviour {
        public readonly Event ConnectedEvent = new Event();
        public readonly Event<DisconnectCause> FailedToConnectEvent = new Event<DisconnectCause>();
        public readonly Event JoinedLobbyEvent = new Event();

        public void CheckConnectToPhoton() {
            if (PhotonNetwork.connected) {
                ConnectedEvent.Trigger();
            }
            else {
                PhotonNetwork.ConnectUsingSettings(NetworkConfig.GameVersion);
            }
        }

        public override void OnConnectedToPhoton() {
            base.OnConnectedToPhoton();
            Debug.Log("NetworkController.OnConnectedToPhoton()");
        }

        public override void OnConnectedToMaster() {
            base.OnConnectedToMaster();
            Debug.Log("NetworkController.OnConnectedToMaster()");
            ConnectedEvent.Trigger();
        }

        public override void OnFailedToConnectToPhoton(DisconnectCause cause) {
            base.OnFailedToConnectToPhoton(cause);
            Debug.Log("NetworkController.OnFailedToConnectToPhoton(" + cause.ToString() + ")");
            FailedToConnectEvent.Trigger(cause);
        }

        public override void OnJoinedLobby() {
            base.OnJoinedLobby();
            Debug.Log("NetworkController.OnJoinedLobby()");
            JoinedLobbyEvent.Trigger();
        }
    }
}