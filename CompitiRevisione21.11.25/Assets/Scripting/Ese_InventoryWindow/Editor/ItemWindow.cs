using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ItemWindow : EditorWindow
{
    private List<ItemSO> _items = new List<ItemSO>();
    private Vector2 _scrollPosition;
    private ItemSO _selectedItem;
    private ItemSO _newItemSO;
    

    [MenuItem("Tools/Item Window")]

    public static void ShowWindow()
    {
        var window = GetWindow<ItemWindow>("Item Window");
        window.minSize = new Vector2(900, 400);
    }

    public void OnFocus()
    {
        FetchAssets(ref _items);
    }

    public void OnGUI()
    {
        GUILayout.BeginHorizontal();
        DrawScollView();
        GUILayout.Space(10);
        DrawItem();
        GUILayout.EndHorizontal();
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
        //GUILayout.BeginVertical();
        //GUILayout.Label("Items in Project:", GUILayout.Width(50)); // NON SO PERCHE MI FA UNO SPAZIO STRANO SE LO METTO
        _scrollPosition = EditorGUILayout.BeginScrollView(_scrollPosition, false, true, GUILayout.ExpandHeight(true), GUILayout.Width(200) );
        foreach (var item in _items)
        {
            DrawItemList(item);
        }
        GUILayout.EndScrollView();
        //GUILayout.EndVertical();
    }
    private void DrawItemList(ItemSO item)
    {
        var prevBackground = GUI.backgroundColor;
        
        if(GUILayout.Button(item.name, GUILayout.Width(200)))
        {
            GUI.backgroundColor = Color.green;
            _selectedItem =  item;
        }

        GUI.backgroundColor = prevBackground;  
    }

    private void DrawItem()
    {
        if (_selectedItem != null)
        {
            _newItemSO = ScriptableObject.CreateInstance<ItemSO>();
            GUILayout.BeginVertical();
            GUILayout.Label("Selected item:");
            GUILayout.Space(10);
            DrawItemName();
            DrawItemIcon();
            DrawItemStats();
            GUILayout.EndVertical();
        }
    }

    private void DrawItemName()
    {
        _newItemSO.name = EditorGUILayout.TextField(_selectedItem.name, GUILayout.Width(100));
    }

    private void DrawItemIcon()
    {
        GUILayout.Box(_selectedItem.icon, GUILayout.Width(_selectedItem.icon.width), GUILayout.Height(_selectedItem.icon.height));
    }

    private void DrawItemStats()
    {
        GUILayout.BeginVertical();
        _newItemSO.value = EditorGUILayout.FloatField("Value", _selectedItem.value, GUILayout.Width(200));
        GUILayout.Space(10);
        DrawItemWeight();
        GUILayout.Space(10);
        DrawItemDimensions();
        GUILayout.Space(10);
        DrawItemDurability();
        GUILayout.EndVertical();
    }

    private void DrawItemWeight()
    {
        GUILayout.BeginHorizontal();
        _newItemSO.weight = EditorGUILayout.FloatField("Weight", _selectedItem.weight, GUILayout.Width(200));
        GUILayout.Space(10);
        GUILayout.Label(DrawWeightLabel(), GUILayout.Width(1000));
        GUILayout.EndHorizontal();
    }

    private string DrawWeightLabel()
    {
        var weightType = "null";
        GUILayout.BeginHorizontal();
        if (_newItemSO.weight <= 5)
        {
            weightType = "Light";
        }else if (_newItemSO.weight <= 10)
        {
            weightType = "Medium";
        }
        else
        {
            weightType = "Heavy";
        }
        GUILayout.EndHorizontal();
        
        return weightType;
    }

    private void DrawItemDimensions()
    {
        GUILayout.BeginHorizontal(GUILayout.Width(200));
        GUILayout.Label("Dimensions:");
        GUILayout.Space(50);
        _newItemSO.dimensions = EditorGUILayout.Vector2IntField("", _selectedItem.dimensions, GUILayout.Width(100));
        GUILayout.Space(50);
        GUILayout.EndHorizontal();
        DrawButtonsDimensions();
    }

    private void DrawButtonsDimensions()
    {
        GUILayout.BeginVertical();
        for (int y = 0; y < _newItemSO.dimensions.y; y++)
        {
            GUILayout.BeginHorizontal();
            for (int x = 0; x < _newItemSO.dimensions.x; x++)
            {
                GUILayout.Button("",GUILayout.Width(30), GUILayout.Height(30));
            }
            GUILayout.EndHorizontal();
        }
        GUILayout.EndVertical();
    }

    private void DrawItemDurability()
    {
        GUILayout.BeginHorizontal(GUILayout.Width(100));
        _newItemSO.currentDurability = EditorGUILayout.IntField("Durability", _selectedItem.currentDurability, GUILayout.Width(200));
        GUILayout.Label("/");
        _newItemSO.maxDurability =  EditorGUILayout.IntField(_selectedItem.maxDurability);
        GUILayout.EndHorizontal();
        DrawDurabilityBar();

    }

    private void DrawDurabilityBar()
    {
        GUILayout.BeginVertical();
        EditorGUI.ProgressBar(new Rect(210, 340, 275, 20), ((_selectedItem.currentDurability/_selectedItem.maxDurability)), _newItemSO.currentDurability.ToString());
        GUILayout.EndVertical();
    }
    
}
