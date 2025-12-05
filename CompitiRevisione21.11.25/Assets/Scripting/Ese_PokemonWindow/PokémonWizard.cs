using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

public class PokémonWizard : EditorWindow
{
    [MenuItem("Tools/PokemonWindow")]

    public static void ShowWindow()
    {
        GetWindow(typeof(PokémonWizard));
    }

    public ScriptableObject Pokemon;

    void OnGUI()
    {
        GUILayout.BeginHorizontal();
        var prova = EditorGUILayout.ObjectField("Pokemon", Pokemon, typeof(ScriptableObject), true);
       

    }

    public void Open(ScriptableObject pokemon)
    {
        
    }
}