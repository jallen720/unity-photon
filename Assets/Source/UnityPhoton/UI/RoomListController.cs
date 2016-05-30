using UnityEngine;

namespace UnityPhoton {
    public class RoomListController : MonoBehaviour {

        [SerializeField]
        private LobbyController lobbyController;

        [SerializeField]
        private GameObject emptyRoomListDisplay;

        [SerializeField]
        private RoomListDisplay roomListDisplay;

        private void Start() {
            lobbyController.ReceivedRoomListEvent.Subscribe(UpdateRoomList);
            UpdateRoomList();
        }

        private void UpdateRoomList() {
            RoomInfo[] roomList = PhotonNetwork.GetRoomList();

            if (roomList.Length == 0) {
                ShowEmptyRoomListDisplay();
            }
            else {
                ShowRoomListDisplay(roomList);
            }
        }

        private void ShowEmptyRoomListDisplay() {
            emptyRoomListDisplay.SetActive(true);
            roomListDisplay.gameObject.SetActive(false);
        }

        private void ShowRoomListDisplay(RoomInfo[] roomList) {
            emptyRoomListDisplay.SetActive(false);
            roomListDisplay.gameObject.SetActive(true);
            roomListDisplay.Load(roomList);
        }
    }
}