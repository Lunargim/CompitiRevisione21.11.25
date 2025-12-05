using UnityEditor;
using UnityEngine;


public class CInematicPreviewWindow : EditorWindow
{
    private static CinematicCameraMovementData _movementData;

    [MenuItem("Tools/CinematicPreview")]
    private void ShowWindow()
    {
        GetWindow<CInematicPreviewWindow>();

    }

    public void OnGUI()
    {
        ShowWindow();

        //qua vanno i metodi

    }


}
