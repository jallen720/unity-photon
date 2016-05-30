using UnityEngine;
using UnityEngine.UI;

namespace UnityPhoton {

    [RequireComponent(typeof(Button))]
    public class LobbyLeaveButtonDisabler : MonoBehaviour {

        [SerializeField]
        private LobbyController lobbyController;

        private void Start() {
            lobbyController.LeftLobbyEvent.Subscribe(() => {
                GetComponent<Button>().interactable = false;
            });
        }
    }
}