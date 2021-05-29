using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveGameManager : MonoBehaviour
{
    public List<ScriptableObject> objects = new List<ScriptableObject>();

    public void ResetScriptables()
    {
        for(int i = 0; i < objects.Count; i++)
        {
            if (File.Exists(Application.persistentDataPath + $"/{i}.dat"))
            {
                File.Delete(Application.persistentDataPath + $"/{i}.dat");
                Debug.Log("Deleted");
            }
        }
    }

    private void OnEnable()
    {
        LoadScriptables();
    }

    private void OnDisable()
    {
        SaveScriptables();
    }

    // save the game
    public void SaveScriptables()
    {
        for(int i =0; i < objects.Count; i++)
        {
            //creating the save files
            FileStream file = File.Create (Application.persistentDataPath + $"/{i}.dat");
            BinaryFormatter binary = new BinaryFormatter();
            var json = JsonUtility.ToJson(objects[i]);
            //put the list of object into json files
            binary.Serialize(file, json);
            file.Close();
            Debug.Log("saved");
        }
    }

    public void LoadScriptables()
    {
        for (int i = 0; i < objects.Count; i++)
        {
            //check if file exist
            if(File.Exists(Application.persistentDataPath + $"/{i}.dat"))
            {
                //open the save files
                FileStream file = File.Open(Application.persistentDataPath + $"/{i}.dat", FileMode.Open);
                BinaryFormatter binary = new BinaryFormatter();
                JsonUtility.FromJsonOverwrite((string)binary.Deserialize(file), objects[i]);
                file.Close();
            }
        }
    }
}
