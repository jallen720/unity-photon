using UnityEngine;
using UnityEngine.UI;

namespace UnityPhoton {
    public class InGameLog : MonoBehaviour {

        [SerializeField]
        private Text log;

        private void Start() {
            log.text = "";
        }

        public void Print(string message) {
            log.text += message;
        }

        public void PrintLine(string message) {
            Print("\n" + message);
        }
    }
}