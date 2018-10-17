using UnityEngine;
using UnityEngine.SceneManagement;

class DefaultButton : TextButton {
    protected override string buttonText {
        get { return "Revert to Defaults"; }
    }
    protected override void clickAction() {
        // Revert to default options
        Options.Instance.merge(Options.DEFAULTS);
        // Reload the scene so that the UI can get reset
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
