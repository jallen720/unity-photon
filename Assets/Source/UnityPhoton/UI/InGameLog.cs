using UnityEngine;
using UnityEngine.UI;

namespace UnityPhoton {

    [RequireComponent(typeof(Text))]
    public class InGameLog : MonoBehaviour {
        private Text log;

        private void Start() {
            log = GetComponent<Text>();
            Init();
        }

        private void Init() {
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