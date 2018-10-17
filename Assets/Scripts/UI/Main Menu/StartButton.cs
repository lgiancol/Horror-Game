using UnityEngine;
using UnityEngine.SceneManagement;

class StartButton : TextButton {
    protected override string buttonText {
        get { return "Start"; }
    }
    protected override void clickAction() {
        SceneManager.LoadScene("Asylum");
    }
}
