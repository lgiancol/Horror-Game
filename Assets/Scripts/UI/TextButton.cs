using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class TextButton : MonoBehaviour {
	// Each subclass must specify the text on the button
	protected abstract string buttonText { get; }

	// They also need to specify the callback for onClick
	protected abstract void clickAction();

	private Text text;
	private Button button;

	// Create the button transition color that every TextButton will use
	// This is static so that we don't recreate it for every new button
	private static ColorBlock BUTTON_COLOURS = new ColorBlock {
		colorMultiplier = 1,
		fadeDuration = 0.15f,
		normalColor = Color.white,
		disabledColor = Color.grey,
		highlightedColor = new Color(1.0f, 0.65f, 0.0f),
		pressedColor = new Color(1.0f, 0.0f, 0.0f),
	};

	static Font loadFont() {
		const string FONT_NAME = "NaziTypewriterRegular";
		// Try to find the font if it's already loaded
		foreach (Font font in Resources.FindObjectsOfTypeAll<Font>()) {
			if (font.name == FONT_NAME) {
				return font;
			}
		}

		// Or else load it if it's the first time
		return Resources.Load<Font>("Fonts/NaziTypewriter/" + FONT_NAME);
	}

	// Use this for initialization
	void Start () {
		// Set up the text field that will be rendered
		text = gameObject.AddComponent<Text>();
		text.font = loadFont();
		text.fontSize = 30;
		text.text = buttonText;
		text.alignment = TextAnchor.MiddleCenter;

		// Create the button to handle clicking
		button = gameObject.AddComponent<Button>();
		button.targetGraphic = text;
		button.colors = BUTTON_COLOURS;
		button.onClick.AddListener(clickAction);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
