using UnityEngine;

namespace UnityPhoton {
    public class RoomListDisplay : MonoBehaviour {
        public void Load(RoomInfo[] roomList) {
            foreach (RoomInfo roomInfo in roomList) {
                Debug.Log("Loading room: " + roomInfo.name);
            }
        }
    }
}