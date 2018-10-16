using UnityEngine;
using UnityEngine.UI;

class MouseSensSlider : MonoBehaviour {
    void Start() {
        // Set the initial value of the slider to what's in the options right now
        Slider slider = GetComponent<Slider>();
        slider.value = (float) Options.Instance.mouseSensitivity;
    }
}
