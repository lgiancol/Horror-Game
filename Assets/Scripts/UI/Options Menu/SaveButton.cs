using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

class SaveButton : TextButton {
    protected override string buttonText {
        get { return "Save Changes"; }
    }
    protected override void clickAction() {
        // Create an option builder that will hold all of the options before we merge it
        Options.OptionsBuilder builder = new Options.OptionsBuilder();
        Slider mouseSens = findObject<Slider>("MouseSens");
        if (mouseSens != null) {
            builder.mouseSensitivity = (uint) mouseSens.value;
        } else {
            Debug.Log("Failed to find the mouse sensitivity slider");
        }

        // Merge the options that we built
        Options.Instance.merge(builder);

        // Go back to the main menu after the new options have been saved
        SceneManager.LoadSceneAsync("Main Menu");
    }

    // Tries to find the object of the given type in the scene with the same name
    private T findObject<T>(string name) where T: UnityEngine.Object {
        foreach (T obj in FindObjectsOfType<T>()) {
            if (obj.name == name) {
                return obj;
            }
        }
        return null;
    }
}
