using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace UnityPhoton {
    public class CreateRoomDialogController : MonoBehaviour {

        [SerializeField]
        private LobbyController lobbyController;

        [SerializeField]
        private Button createButton;

        [SerializeField]
        private Button cancelButton;

        [SerializeField]
        private Text roomNameText;

        [SerializeField]
        private ErrorDisplay errorDisplay;

        private readonly List<Validation<string>> roomNameValidations =
            new List<Validation<string>> {
                new Validation<string> {
                    isValid = (string roomName) => roomName != "",
                    errorMessage = "Room name cannot be empty"
                },
                new Validation<string> {
                    isValid = IsUnique,
                    errorMessage = "A room with that name already exists"
                }
            };

        private void Start() {
            createButton.onClick.AddListener(CheckCreateRoom);
            cancelButton.onClick.AddListener(errorDisplay.Clear);
        }

        private void CheckCreateRoom() {
            List<string> errorMessages;

            if (RoomNameIsValid(out errorMessages)) {
                CreateRoom();
            }
            else {
                errorDisplay.SetErrors(errorMessages);
            }
        }

        private bool RoomNameIsValid(out List<string> errorMessages) {
            errorMessages = new List<string>(
                roomNameValidations
                    .FindAll(validation => !validation.isValid(roomNameText.text))
                    .Select(validation => validation.errorMessage));

            return errorMessages.Count == 0;
        }

        private void CreateRoom() {
            lobbyController.FlagAsJoiningRoom();
            PhotonNetwork.CreateRoom(roomNameText.text);
            Close();
        }

        private void Close() {
            errorDisplay.Clear();
            gameObject.SetActive(false);
        }

        private struct Validation<T> {
            public Predicate<T> isValid;
            public string errorMessage;
        }

        // Static members

        private static bool IsUnique(string roomName) {
            return !Array.Exists(
                PhotonNetwork.GetRoomList(),
                (RoomInfo roomInfo) => roomInfo.name == roomName);
        }
    }
}
