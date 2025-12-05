using UnityEditor;
using UnityEngine;

public class PokemonEditor : Editor
{
    [CustomEditor(typeof(Pokemon))]

    PokémonWizard PokemonW;
    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("CheckPokemon", GUILayout.Height(20), GUILayout.Width(20)))
        {
            PokemonW.Open(this);
        }

    }

    }
