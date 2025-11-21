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
         string fileJson = Path.Combine("C:/Users/loryl/Desktop/Esercizio Deserializzazione.txt");
         
         if(File.Exists(fileJson))
         {
             string jsonString = File.ReadAllText(fileJson);
             JsonUtility.FromJsonOverwrite(jsonString, data);
             
             //JsonConvert.DeserializeObject<MyData>(jsonString);
         }else
         {
             Debug.Log("File Json not found");
         }
         
     }
}
