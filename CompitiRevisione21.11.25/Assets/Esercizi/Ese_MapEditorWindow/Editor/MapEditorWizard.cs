using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    private List<int> _buttonsPressedIndex = new List<int>();
    private List<string> _buttonsLetter = new List<string>();
    

    [MenuItem("Tools/Map Editor")]

    public static void ShowWindow()
    {
        var window = GetWindow<MapEditorWizard>();
        window.minSize = new Vector2(900, 400);
    }
    
    private void OnGUI()
    {
        LoadButtonsLetter();
        DrawSizeMap();
        EditorGUILayout.Space(30);
        DrawPrefabList();
        EditorGUILayout.Space(30);
        DrawMap();
    }

    private void OnFocus()
    {
        _prefab = Resources.LoadAll<GameObject>( "ResourceEseEditorMap/Prefab").ToList();
    }
 

    private void DrawSizeMap()
    {
        _mapSize = EditorGUILayout.Vector2IntField("Map size", _mapSize, GUILayout.Width(200));
    }

    private void DrawPrefabList()
    {
        LoadDictionary();
        
        GUILayout.BeginVertical();
        
        _prefabScrollPosition = EditorGUILayout.BeginScrollView(_prefabScrollPosition, false, true,  GUILayout.Height(150), GUILayout.Width(150));

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
            GUILayout.BeginHorizontal(GUILayout.Width(20));
            if(GUILayout.Button(item.Key, GUILayout.Width(30)))
            {
                GiveLetterToButton(item.Key);
            }
            GUILayout.Space(10);
            GUILayout.Label(item.Value.name, GUILayout.Width(50));
            GUILayout.EndHorizontal();
        }
        GUILayout.EndVertical();
    }
    
    private void DrawMap()
    {
        var prevBackground = GUI.backgroundColor;

        /*foreach (var item in _buttonsPressed)
        {
            if (item)
            {
                GUI.backgroundColor = Color.yellow;
            }
        }*/
        
        GUILayout.BeginVertical();
        for (int y = 0; y < _mapSize.y; y++)
        {
            GUILayout.BeginHorizontal();
            for (int x = 0; x < _mapSize.x; x++)
            {
                if ( GUILayout.Button(_buttonsLetter[x], GUILayout.Width(30), GUILayout.Height(30)))
                {
                    Debug.Log("AAAAA");
                    _buttonsPressedIndex.Add(x);
                    Debug.Log(_buttonsPressedIndex[0]);
                }
            }
            GUILayout.EndHorizontal();
        }
        GUILayout.EndVertical();
        GUI.backgroundColor = prevBackground;
    }

    private void GiveLetterToButton(string letter)
    {
        if (_buttonsPressedIndex.Count >= 1)
        {
            for (int i = 0; i < (_mapSize.x * _mapSize.y) ; i++)
            {
                if (_buttonsPressedIndex.Contains(i))
                {
                    _buttonsLetter.Add(letter);
                }
                else
                {
                    _buttonsLetter.Add("");
                }
            }
        }
        
    }

    private void LoadButtonsLetter()
    {
        if (_buttonsPressedIndex.Count < 1)
        {
            for (int i = 0; i < (_mapSize.x * _mapSize.y); i++)
            {
                _buttonsLetter.Add("");
            }
        }
    }

}


