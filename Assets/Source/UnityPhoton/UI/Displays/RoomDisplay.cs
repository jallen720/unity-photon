using UnityEngine;
using UnityEngine.UI;

namespace UnityPhoton {
    public class RoomDisplay : MonoBehaviour {

        [SerializeField]
        private Text nameText;

        [SerializeField]
        private JoinRoomButton joinButton;

        public void Init(RoomInfo roomInfo, LobbyController lobbyController) {
            nameText.text = roomInfo.name;
            joinButton.Init(roomInfo.name, lobbyController);
        }
    }
}