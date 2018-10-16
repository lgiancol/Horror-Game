using UnityEngine;

class StartButton : TextButton {
    protected override string buttonText {
        get { return "Start"; }
    }
    protected override void clickAction() {
        Debug.Log("Start Button");
    }
}
