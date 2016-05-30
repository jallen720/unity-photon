using UnityEngine;
using UnityEngine.UI;

namespace UnityPhoton {
    public class CreateRoomDialog : MonoBehaviour {

        [SerializeField]
        private LobbyController lobbyController;

        [SerializeField]
        private Button createButton;

        [SerializeField]
        private Text roomNameText;

        private void Start() {
            createButton.onClick.AddListener(CheckCreateRoom);
        }

        private void CheckCreateRoom() {
            CreateRoom();
        }

        private void CreateRoom() {
            lobbyController.FlagAsJoiningRoom();
            PhotonNetwork.CreateRoom(roomNameText.text);
            gameObject.SetActive(false);
        }
    }
}
