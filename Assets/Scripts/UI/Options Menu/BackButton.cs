using UnityEngine;
using UnityEngine.SceneManagement;

// This is a generic-ish back button that will unload the current scene
class BackButton : TextButton {
    protected override string buttonText {
        get { return "Back"; }
    }
    protected override void clickAction() {
        // Go back to the main menu
        SceneManager.LoadSceneAsync("Main Menu");
    }
}
