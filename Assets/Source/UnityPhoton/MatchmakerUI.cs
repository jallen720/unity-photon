using UnityEngine;

namespace UnityPhoton {
    public class MatchmakerUI : MonoBehaviour {

        [SerializeField]
        private ConnectionStateObserver connectionStateObserver;

        [SerializeField]
        private InGameLog log;

        private void Start() {
            connectionStateObserver.NewConnectionStateEvent.Subscribe(log.PrintLine);
        }
    }
}