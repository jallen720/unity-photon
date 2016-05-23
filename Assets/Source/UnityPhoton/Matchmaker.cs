using ExitGames.Client.Photon;
using Photon;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UnityPhoton {
    public class Matchmaker : PunBehaviour {

        [SerializeField]
        private CharacterSpawner characterSpawner;

        private void Start() {
            PhotonNetwork.ConnectUsingSettings("0.1");
        }

        public override void OnConnectedToPhoton() {
            base.OnConnectedToPhoton();
            Debug.Log("OnConnectedToPhoton()");
        }

        public override void OnConnectedToMaster() {
            base.OnConnectedToMaster();
            Debug.Log("OnConnectedToMaster()");
            PhotonNetwork.JoinLobby();
        }

        public override void OnJoinedLobby() {
            base.OnJoinedLobby();
            Debug.Log("OnJoinedLobby()");
            PhotonNetwork.JoinRandomRoom();
        }

        public override void OnReceivedRoomListUpdate() {
            base.OnReceivedRoomListUpdate();
            Debug.Log("OnReceivedRoomListUpdate()");
        }

        private void OnPhotonRandomJoinFailed() {
            Debug.Log("OnPhotonRandomJoinFailed()");

            // Couldn't join random room; create new one.
            PhotonNetwork.CreateRoom(null);
        }

        public override void OnLeftLobby() {
            base.OnLeftLobby();
            Debug.Log("OnLeftLobby()");
        }

        public override void OnPhotonCustomRoomPropertiesChanged(Hashtable propertiesThatChanged) {
            base.OnPhotonCustomRoomPropertiesChanged(propertiesThatChanged);

            Debug.Log(propertiesThatChanged.Aggregate(
                "OnPhotonCustomRoomPropertiesChanged():\n",
                PropertiesAggregator));
        }

        private string PropertiesAggregator(string message, KeyValuePair<object, object> property) {
            return message + "    { " +
                   property.Key.ToString() + ", " +
                   property.Value.ToString() + " }\n";
        }

        public override void OnCreatedRoom() {
            base.OnCreatedRoom();
            Debug.Log("OnCreatedRoom()");
        }

        public override void OnJoinedRoom() {
            base.OnJoinedRoom();
            Debug.Log("OnJoinedRoom()");
            characterSpawner.SpawnCharacter();
        }

        public override void OnLeftRoom() {
            base.OnLeftRoom();
            Debug.Log("OnLeftRoom()");
        }

        public override void OnDisconnectedFromPhoton() {
            base.OnDisconnectedFromPhoton();
            Debug.Log("OnDisconnectedFromPhoton()");
        }

        #region Event handlers
        public override void OnConnectionFail(DisconnectCause cause) {
            base.OnConnectionFail(cause);
            Debug.Log("OnConnectionFail()");
        }

        public override void OnCustomAuthenticationFailed(string debugMessage) {
            base.OnCustomAuthenticationFailed(debugMessage);
            Debug.Log("OnCustomAuthenticationFailed()");
        }

        public override void OnCustomAuthenticationResponse(Dictionary<string, object> data) {
            base.OnCustomAuthenticationResponse(data);
            Debug.Log("OnCustomAuthenticationResponse()");
        }

        public override void OnFailedToConnectToPhoton(DisconnectCause cause) {
            base.OnFailedToConnectToPhoton(cause);
            Debug.Log("OnFailedToConnectToPhoton()");
        }

        public override void OnLobbyStatisticsUpdate() {
            base.OnLobbyStatisticsUpdate();
            Debug.Log("OnLobbyStatisticsUpdate()");
        }

        public override void OnMasterClientSwitched(PhotonPlayer newMasterClient) {
            base.OnMasterClientSwitched(newMasterClient);
            Debug.Log("OnMasterClientSwitched()");
        }

        public override void OnOwnershipRequest(object[] viewAndPlayer) {
            base.OnOwnershipRequest(viewAndPlayer);
            Debug.Log("OnOwnershipRequest()");
        }

        public override void OnPhotonCreateRoomFailed(object[] codeAndMsg) {
            base.OnPhotonCreateRoomFailed(codeAndMsg);
            Debug.Log("OnPhotonCreateRoomFailed()");
        }

        public override void OnPhotonInstantiate(PhotonMessageInfo info) {
            base.OnPhotonInstantiate(info);
            Debug.Log("OnPhotonInstantiate()");
        }

        public override void OnPhotonJoinRoomFailed(object[] codeAndMsg) {
            base.OnPhotonJoinRoomFailed(codeAndMsg);
            Debug.Log("OnPhotonJoinRoomFailed()");
        }

        public override void OnPhotonMaxCccuReached() {
            base.OnPhotonMaxCccuReached();
            Debug.Log("OnPhotonMaxCccuReached()");
        }

        public override void OnPhotonPlayerConnected(PhotonPlayer newPlayer) {
            base.OnPhotonPlayerConnected(newPlayer);
            Debug.Log("OnPhotonPlayerConnected()");
        }

        public override void OnPhotonPlayerDisconnected(PhotonPlayer otherPlayer) {
            base.OnPhotonPlayerDisconnected(otherPlayer);
            Debug.Log("OnPhotonPlayerDisconnected()");
        }

        public override void OnPhotonPlayerPropertiesChanged(object[] playerAndUpdatedProps) {
            base.OnPhotonPlayerPropertiesChanged(playerAndUpdatedProps);
            Debug.Log("OnPhotonPlayerPropertiesChanged()");
        }

        public override void OnPhotonRandomJoinFailed(object[] codeAndMsg) {
            base.OnPhotonRandomJoinFailed(codeAndMsg);
            Debug.Log("OnPhotonRandomJoinFailed()");
        }

        public override void OnUpdatedFriendList() {
            base.OnUpdatedFriendList();
            Debug.Log("OnUpdatedFriendList()");
        }

        public override void OnWebRpcResponse(OperationResponse response) {
            base.OnWebRpcResponse(response);
            Debug.Log("OnWebRpcResponse()");
        }
        #endregion Event handlers
    }
}
