using UnityEditor;
using UnityEngine;


public class CInematicPreviewWindow : EditorWindow
{
    private static CinematicCameraMovementData _movementData;

    [MenuItem("Tools/CinematicPreview")]
    private static void ShowWindow()
    {
        GetWindow<CInematicPreviewWindow>();
    }

    void OnEnable()
    {
        //_movementData = target as CinematicCameraMovementData;
    }

    public void OnGUI()
    {
        ShowWindow();

        InsertCinematicCameraScriptables();
        

    }

    private void InsertCinematicCameraScriptables()
    {
        GUILayout.Label("Inserisci lo scriptable");
        GUILayout.Space(EditorGUIUtility.singleLineHeight);
        EditorGUILayout.ObjectField("Scriptables", _movementData, typeof(CinematicCameraMovementData), false);
        //var _data = Target as CinematicCameraMovementData;
    }

}
