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
            if (obj.GetComponent<MeshRenderer>().sharedMaterial == null )
            {
                objectSelected.Add( Selection.gameObjects[objectsIndex]);
                objectsIndex++;
            }

            if (obj.GetComponent<MeshRenderer>().sharedMaterial != null)
            {
                selectedMaterial.Add(Selection.gameObjects[colorsIndex].GetComponent<MeshRenderer>().sharedMaterial);
                colorsIndex++;
            }
        }
  
        foreach (GameObject obj in objectSelected)
        {
            obj.gameObject.GetComponent<MeshRenderer>().sharedMaterial = selectedMaterial[0];
        }
    }

    [MenuItem("Mio Menu/Planetary System %#F1", true)]

    static bool CheckMaterial()
    {
        bool materialMissing = false;
        bool materialFound = false;
        foreach (GameObject obj in Selection.gameObjects)
        {
            if (obj.GetComponent<MeshRenderer>().sharedMaterial == null)
            {
                materialMissing = true;
            }

            if (obj.GetComponent<MeshRenderer>().sharedMaterial != null)
            {
                materialFound = true;
            }
        }

        if (!materialMissing && materialFound)
        {
            return true;
        }

        return false;
    }
}
