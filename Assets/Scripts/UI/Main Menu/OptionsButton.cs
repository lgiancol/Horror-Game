using UnityEngine;
using UnityEngine.SceneManagement;

class OptionsButton : TextButton {
    protected override string buttonText {
        get { return "Options"; }
    }
    protected override void clickAction() {
        // Load the options menu without unloading this one
        SceneManager.LoadSceneAsync("Options Menu");
    }
}
