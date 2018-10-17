using UnityEngine;
using UnityEngine.UI;

public class ActionPanelUI : MonoBehaviour {
	public Text messageBox;
	public bool messageSet = false;

	public void setActionText(string msg) {
		this.messageBox.text = msg;
		messageSet = true;
	}

	public void resetActionText() {
		this.messageBox.text = "";
		messageSet = false;
	}

}
