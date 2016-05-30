using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityPhoton {
    public class MainMenuTransitionController : MonoBehaviour {

        [SerializeField]
        private NetworkController networkController;

        private void Start() {
            networkController.JoinedLobbyEvent.Subscribe(() => {
                Debug.Log("Successfully joined lobby");
                SceneManager.LoadScene("Lobby");
            });
        }
    }
}