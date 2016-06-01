using Photon;
using UnityEngine;

namespace UnityPhoton {
    public class PlayerListDisplay : PunBehaviour {

        [SerializeField]
        private RectTransform playerDisplayContainer;

        [SerializeField]
        private Object playerDisplayPrefab;

        private ListDisplay<PhotonPlayer, PlayerDisplay> listDisplay;

        private void Start() {
            listDisplay =
                new ListDisplay<PhotonPlayer, PlayerDisplay>(
                    playerDisplayContainer,
                    playerDisplayPrefab);

            UpdatePlayerList();
        }

        public override void OnPhotonPlayerConnected(PhotonPlayer newPlayer) {
            base.OnPhotonPlayerConnected(newPlayer);
            UpdatePlayerList();
        }

        public override void OnPhotonPlayerDisconnected(PhotonPlayer newPlayer) {
            base.OnPhotonPlayerDisconnected(newPlayer);
            UpdatePlayerList();
        }

        private void UpdatePlayerList() {
            listDisplay.Load(PhotonNetwork.playerList);
        }
    }
}