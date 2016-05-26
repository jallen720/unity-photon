using Photon;
using UnityUtils.EventUtils;
using Debug = UnityEngine.Debug;

namespace UnityPhoton {
    public class NetworkController : PunBehaviour {
        private Event connectedEvent;
        private Event<DisconnectCause> failedToConnectEvent;

        public Event ConnectedEvent {
            get {
                return connectedEvent ?? LoadConnectedEvent();
            }
        }

        public Event<DisconnectCause> FailedToConnectEvent {
            get {
                return failedToConnectEvent ?? LoadFailedToConnectEvent();
            }
        }

        private Event LoadConnectedEvent() {
            return connectedEvent = new Event();
        }

        private Event<DisconnectCause> LoadFailedToConnectEvent() {
            return failedToConnectEvent = new Event<DisconnectCause>();
        }

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
    }
}