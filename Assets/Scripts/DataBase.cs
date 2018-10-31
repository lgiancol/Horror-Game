using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class DataBase {

    public static string fbUrl = "https://goons-13756.firebaseio.com/";

    // Retrieves player data from database.
    public void retrievePlayerData()
    {

        // Set up editor & get root reference location.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(fbUrl);
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;


        FirebaseDatabase.DefaultInstance.GetReference("goons-13756").GetValueAsync().ContinueWith(task => {
            if (task.IsFaulted)
            {
                Debug.Log("Fail");
            }
            else if (task.IsCompleted)
            {
                Debug.Log("Pass!");
                DataSnapshot snapshot = task.Result;
                Debug.Log(snapshot.GetRawJsonValue());
            }
        });


    }

    // Once game is completed, game data is added to the database.
    public void addPlayerData()
    {

        playerData newPlayer = new playerData(2/*"Kushal", 1899, 22, 165*/);
        string jason = JsonUtility.ToJson(newPlayer);

        // Set up editor & get root reference location.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(fbUrl);
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

        // Push gives data a unique ID. Once we get more player data we don't have to use push.
        reference.Push().SetRawJsonValueAsync(jason);
        Debug.Log("We are winning!");


    }

    // Json string format.
    public class playerData
    {
        /*public string id = "";
        public int time = 0;
        public string inventory = "";*/
        public int levels_completed = 0;

        public playerData(int levels_completed/*string id, int time, string inventory*/)
        {
            /*this.id = id;
            this.time = time;
            this.inventory = inventory;*/
            this.levels_completed = levels_completed;
        }

        public string toString() {
            return ("Levels Completed: " + this.levels_completed); 
        }
    }
}
