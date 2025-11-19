using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MaterialFixer
{
    [MenuItem("Tools/Material Fixer %&F9")]

    static void MaterialFix()
    {
        int colorsIndex = 0;
        int objectsIndex = 0;
        List<GameObject> objectSelected = new List<GameObject>();
        List<Material> selectedMaterial = new List<Material>();
        
        foreach (GameObject obj in Selection.gameObjects)
        {
            if (obj.GetComponent<MeshRenderer>().material == null) //|| !obj.GetComponent<MeshRenderer>().material.enableInstancing )
            {
                objectSelected.Add(Selection.gameObjects[objectsIndex]);
                objectsIndex++;
            }

            if (obj.GetComponent<MeshRenderer>().material != null)
            {
                selectedMaterial.Add(Selection.gameObjects[colorsIndex].GetComponent<Material>());
                colorsIndex++;
            }
        }
        
        foreach (GameObject obj in objectSelected)
        {
            obj.gameObject.GetComponent<MeshRenderer>().material = selectedMaterial[0];
        }
    }
    
}
