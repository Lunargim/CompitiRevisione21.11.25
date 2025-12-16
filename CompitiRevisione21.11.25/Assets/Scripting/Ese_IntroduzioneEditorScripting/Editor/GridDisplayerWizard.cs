using UnityEditor;
using UnityEngine;

public class GridDisplayerWizard : EditorWindow
{


    [MenuItem("Tools/GridDisplayer")]

    public static void ShowWindow()
    {
        GetWindow<GridDisplayerWizard>("GridDisplayer");
    }
    
}
