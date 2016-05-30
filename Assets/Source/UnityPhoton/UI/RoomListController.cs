using Photon;
using UnityEngine;

namespace UnityPhoton {
    public class RoomListController : PunBehaviour {

        [SerializeField]
        private GameObject emptyRoomListDisplay;

        [SerializeField]
        private RoomListDisplay roomListDisplay;

        private void Start() {
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

        public override void OnReceivedRoomListUpdate() {
            base.OnReceivedRoomListUpdate();
            UpdateRoomList();
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