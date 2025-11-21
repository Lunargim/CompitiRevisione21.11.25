using System.IO;
using UnityEngine;

public class Deserialization : MonoBehaviour
{
    public MyData data;
    private void Start()
    {
        Load();
    }

    public void Load()
    {
        if(File.Exixts(jsonString))
        {
            string jsonString = File.ReadAllText("C:/Users/loryl/Desktop/Esercizio Deserializzazione.txt");
            Mydata = JsonUtility.FromJsonOverwrite(jsonString, data);
            
            //JsonConvert.DeserializeObject<MyData>(jsonString);
        }else
        {
            Debug.Log("File Json not found");
        }
        
    }
}
