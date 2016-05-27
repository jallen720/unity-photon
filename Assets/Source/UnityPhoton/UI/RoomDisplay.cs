using UnityEngine;
using UnityEngine.UI;

namespace UnityPhoton {
    public class RoomDisplay : MonoBehaviour {

        [SerializeField]
        private Text roomNameText;

        public void Init(RoomInfo roomInfo) {
            roomNameText.text = roomInfo.name;
        }
    }
}