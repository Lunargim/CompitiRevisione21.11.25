using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class MapEditorWizard : EditorWindow
{
    private Vector2Int _mapSize;
    private List<GameObject> _prefab = new List<GameObject>();
    private Dictionary<string, GameObject> _prefabDictionary = new Dictionary<string, GameObject>();
    private string _alphabet = "abcdefghijklmnopqrstuvwxyz";
    private Vector2 _prefabScrollPosition;

    [MenuItem("Tools/Map Editor")]

    public static void ShowWindow()
    {
        var window = GetWindow<MapEditorWizard>();
        window.minSize = new Vector2(900, 400);
    }
    
    private void OnGUI()
    {
        DrawSizeMap();
        DrawPrefabList();
    }

    private void OnFocus()
    {
        _prefab = Resources.LoadAll<GameObject>( "Assets/Esercizi/Ese_MapEditorWindow/Prefab").ToList();
    }
 

    private void DrawSizeMap()
    {
        _mapSize = EditorGUILayout.Vector2IntField("Map size", _mapSize);
    }

    private void DrawPrefabList()
    {
        LoadDictionary();
        GUILayout.BeginVertical();
        _prefabScrollPosition = EditorGUILayout.BeginScrollView(_prefabScrollPosition, false, true);

        DrawPrefabDicitonary();
        
        GUILayout.EndScrollView();
        GUILayout.EndVertical();

    }

    private void LoadDictionary()
    {
        _prefabDictionary.Clear();
        var index = 0;

        foreach (var item in _prefab)
        {
            _prefabDictionary.Add(_alphabet[index].ToString().ToUpper(), item);
            index++;
        }
    }

    private void DrawPrefabDicitonary()
    {
        GUILayout.BeginVertical();
        foreach (var item in _prefabDictionary)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label(item.Key);
            GUILayout.Space(20);
            GUILayout.Label(item.Value.name);
            GUILayout.EndHorizontal();
        }
        GUILayout.EndVertical();
    }
    
}
