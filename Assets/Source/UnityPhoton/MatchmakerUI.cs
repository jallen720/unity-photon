using UnityEngine;
using UnityEngine.UI;

namespace UnityPhoton {
    public class MatchmakerUI : MonoBehaviour {

        [SerializeField]
        private Text status;

        [SerializeField]
        private ConnectionStateObserver connectionStateObserver;

        private void Start() {
            connectionStateObserver.NewConnectionStateEvent.Subscribe(OnNewConnectionState);
            status.text = "";
        }

        private void OnNewConnectionState(string newConnectionState) {
            status.text += newConnectionState + "\n";
        }
    }
}