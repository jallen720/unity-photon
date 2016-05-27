using System;
using UnityEngine;
using UnityUtils.Extensions;
using UObject = UnityEngine.Object;

namespace UnityPhoton {
    public class RoomListDisplay : MonoBehaviour {

        [SerializeField]
        private RectTransform roomDisplayContainer;

        [SerializeField]
        private UObject roomDisplayPrefab;

        public void Load(RoomInfo[] roomList) {
            DestroyOldRoomDisplays();
            Array.ForEach(roomList, LoadRoomDisplay);
        }

        private void DestroyOldRoomDisplays() {
            foreach (Transform roomDisplay in roomDisplayContainer) {
                Destroy(roomDisplay.gameObject);
            }
        }

        private void LoadRoomDisplay(RoomInfo roomInfo) {
            roomDisplayContainer
                .InstantiateChild<RoomDisplay>(roomDisplayPrefab)
                .Init(roomInfo);
        }
    }
}