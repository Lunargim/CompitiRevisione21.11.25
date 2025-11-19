using System.IO;
using UnityEngine;

public class Deserialization : MonoBehaviour
{
    public MyData data;
    private void Awake()
    {
        Load();
    }

    public void Load()
    {
        string jsonString = File.ReadAllText("C:/Users/loryl/Desktop/Esercizio Deserializzazione.txt");
        JsonUtility.FromJsonOverwrite(jsonString, data);
        
        //NEWTON 
        // data = JsonConvert.DeserializeObject<MyData>(jsonString);
    }
    
    [ContextMenu("Save File")]
    public void Save()
    {
        string jsonString = JsonUtility.ToJson(data, true);
        
        //NEWTON
        //string jsonString1 = JsonConvert.SerializeObject(data, Formatting.Indented);
        
        File.WriteAllText("C:/Users/loryl/Desktop/Esercizio Deserializzazione.txt", jsonString);
    }
}
