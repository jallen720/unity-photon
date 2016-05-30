using UnityEngine;

namespace UnityPhoton {
    public class LobbyTransitionController : MonoBehaviour {

        [SerializeField]
        private LobbyController lobbyController;

        private void Start() {
            //lobbyController.LeftLobbyEvent.Subscribe(() => {
            //    if (PhotonNetwork.inRoom) {
            //        Debug.Log("Going to room");
            //    }
            //    else {
            //        Debug.Log("Going to main menu");
            //    }
            //});
        }
    }
}