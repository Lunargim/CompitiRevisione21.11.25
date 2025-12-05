using UnityEditor;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class CInematicPreviewWindow : EditorWindow
{
    
    private static CinematicCameraMovementData _movementData;


    private void OnGUI()
    {
        GetWindow<CInematicPreviewWindow>();

        if( _movementData == null)
        {
           var window = GetWindow<CInematicPreviewWindow>();
            window.Close();
        }

        // qui mettiamo i metodi



    }


}
