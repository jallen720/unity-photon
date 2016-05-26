using UnityEngine;

namespace UnityPhoton {
    public class ConnectionLogController : MonoBehaviour {

        [SerializeField]
        private InGameLog log;

        [SerializeField]
        private ConnectionStateObserver connectionStateObserver;

        private void Start() {
            connectionStateObserver.NewConnectionStateEvent.Subscribe(log.PrintLine);
        }
    }
}