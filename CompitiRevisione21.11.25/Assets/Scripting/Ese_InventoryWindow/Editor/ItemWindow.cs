using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ItemWindow : EditorWindow
{
    private List<ItemSO> _items = new List<ItemSO>();
    private Vector2 _scrollPosition;
    private ItemSO _selectedItem;

    [MenuItem("Tools/Item Window")]

    public static void ShowWindow()
    {
        GetWindow<ItemWindow>("Item Window");
    }

    public void OnFocus()
    {
        FetchAssets(ref _items);
        
        
    }

    public void OnGUI()
    {
        DrawScollView();
    }


    private void FetchAssets<T>(ref List<T> assets) where T : ScriptableObject
    {
        assets = new List<T>(); 
        var assetsGuids = AssetDatabase.FindAssets($"t:{typeof(T)}");
        foreach (var assetGuid in assetsGuids)
        {
            var path = AssetDatabase.GUIDToAssetPath(assetGuid);
            var asset = AssetDatabase.LoadAssetAtPath<T>(path);
            assets.Add(asset);
        }
    }

    private void DrawScollView()
    {
        GUILayout.BeginVertical();
        GUILayout.Label("Items in Project:", GUILayout.Width(50));
        GUILayout.Space(50);
        _scrollPosition = EditorGUILayout.BeginScrollView(_scrollPosition, false, true);
        foreach (var item in _items)
        {
            DrawItemList(item);
        }

        GUILayout.EndScrollView();
        GUILayout.EndVertical();
    }


    private void DrawItemList(ItemSO item)
    {
        var prevBackground = GUI.backgroundColor;
        
        if(GUILayout.Button(item.name, GUILayout.Width(50)))
        {
            GUI.backgroundColor = Color.green;
            _selectedItem =  item;
        }

        GUI.backgroundColor = prevBackground;  
    }
    
}
