using UnityEngine;


public class EndTrigger : MonoBehaviour {

    private void OnTriggerEnter()
    {
        DataBase save = new DataBase();
        save.addPlayerData();
        Debug.Log("Congradulations Mother Fucker!!");
    }
}
