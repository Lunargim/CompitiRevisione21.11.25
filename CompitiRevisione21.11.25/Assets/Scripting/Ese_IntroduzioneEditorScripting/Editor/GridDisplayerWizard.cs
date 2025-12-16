using System;
using System.Net;
using Codice.Client.BaseCommands;
using UnityEditor;
using UnityEngine;

public class GridDisplayerWizard : EditorWindow
{
    private Grid _gridSO;
    private float _gridCellSize;
    private Vector2Int _gridSize;
    private Grid _tempGridSO;

    [MenuItem("Tools/GridDisplayer")]

    public static void ShowWindow()
    {
        GetWindow<GridDisplayerWizard>("GridDisplayer");
    }

    public void OnGUI()
    {
        GUILayout.BeginVertical();
        DrawGCSField();
        DrawGSField();
        DrawSOField();
        DrawGrid();
        DrawButtons();
        GUILayout.EndVertical();
    }

    public void DrawGCSField()
    {
        _gridCellSize = EditorGUILayout.FloatField("Cell Size", _gridCellSize,GUILayout.Width(300));
    }

    public void DrawGSField()
    {
        _gridSize = EditorGUILayout.Vector2IntField("Grid Size", _gridSize, GUILayout.Width(300));
    }

    public void DrawSOField()
    {
        _gridSO = EditorGUILayout.ObjectField("Grid", _gridSO, typeof(ScriptableObject), true, GUILayout.Width(300)) as Grid;
    }

    public void DrawGrid()
    {
        var _previousBackGroundColor = GUI.backgroundColor;

        for (int y = 0; y < _gridSize.y; y++)
        {
            GUILayout.BeginHorizontal();
            for (int x = 0; x < _gridSize.x; x++)
            {
                var index = y * (x * y) + x;
                if (GUILayout.Button(index.ToString(), GUILayout.Width(_gridCellSize), GUILayout.Height(_gridCellSize)))
                {
                    if (_previousBackGroundColor == GUI.backgroundColor)
                    {
                        GUI.backgroundColor = Color.green;
                    }
                    else
                    {
                        GUI.backgroundColor = _previousBackGroundColor;
                    }
                }
                GUI.backgroundColor = _previousBackGroundColor;
            }
            GUILayout.EndHorizontal();
        }
    }

    private void DrawButtons()
    {
        if (GUILayout.Button("Save"))
        {
            SaveSettings();
        }
    }

    private void SaveSettings()
    {
        if (_gridSO  == null)
        {
            Debug.LogWarning("Nessun GridSettings selezionato.");
            return;
        }

        Undo.RecordObject(_gridSO , "Save Grid Settings");

        _gridSO._gridCellSize = _gridCellSize;
        _gridSO._gridSize = _gridSize;

        EditorUtility.SetDirty(_gridSO);
        AssetDatabase.SaveAssets();
    }
    
}
