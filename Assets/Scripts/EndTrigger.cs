using UnityEngine;


public class EndTrigger : MonoBehaviour {
    private AudioSource pickDoor;


    void Start() {
        pickDoor = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter()
    {
        DataBase save = new DataBase();
        save.addPlayerData();
        
        pickDoor.Play();
    }
}
