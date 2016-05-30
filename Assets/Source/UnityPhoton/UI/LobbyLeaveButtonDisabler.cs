using Photon;
using UnityEngine;
using UnityEngine.UI;

namespace UnityPhoton {

    [RequireComponent(typeof(Button))]
    public class LobbyLeaveButtonDisabler : PunBehaviour {
        public override void OnLeftLobby() {
            base.OnLeftLobby();
            GetComponent<Button>().interactable = false;
        }
    }
}