using UnityEngine;

class ExitButton : TextButton {
    protected override string buttonText {
        get { return "Exit"; }
    }

    protected override void clickAction() {
        Application.Quit();
    }
}
