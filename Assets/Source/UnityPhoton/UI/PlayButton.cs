using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UnityPhoton {

    [RequireComponent(typeof(Button))]
    public class PlayButton : MonoBehaviour {

        [SerializeField]
        private NetworkController networkController;

        private Button button;

        private void Start() {
            button = GetComponent<Button>();
            Init();
        }

        private void Init() {
            networkController.ConnectedEvent.Subscribe(OnConnected);
            networkController.FailedToConnectEvent.Subscribe(OnFailedToConnectToPhoton);
            button.onClick.AddListener(CheckConnect);
        }

        private void OnConnected() {
            Debug.Log("Successfully connected to Photon");
            SceneManager.LoadScene("Lobby");
        }

        private void OnFailedToConnectToPhoton(DisconnectCause cause) {
            button.interactable = true;
            Debug.LogError("Failed to connect to Photon: " + cause.ToString());
        }

        private void CheckConnect() {
            button.interactable = false;
            networkController.CheckConnectToPhoton();
        }
    }
}