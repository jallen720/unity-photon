using UnityEngine;
using UnityEngine.UI;

namespace UnityPhoton {

    [RequireComponent(typeof(Button))]
    public class CreateRoomButton : MonoBehaviour {

        [SerializeField]
        private LobbyController lobbyController;

        private Button button;

        private void Start() {
            button = GetComponent<Button>();
            Init();
        }

        private void Init() {
            lobbyController.JoinedLobbyEvent.Subscribe(() => button.interactable = true);
            lobbyController.LeftLobbyEvent.Subscribe(() => button.interactable = false);
        }
    }
}