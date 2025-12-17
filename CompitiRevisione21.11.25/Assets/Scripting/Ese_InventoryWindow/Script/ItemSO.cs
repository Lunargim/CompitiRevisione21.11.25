using UnityEngine;

[CreateAssetMenu(fileName = "item", menuName = "Scriptable Objects/item")]
public class ItemSO : ScriptableObject
{
    public string name;
    public Texture icon;
    public float value;
    public float weight;
    public Vector2Int dimensions;
    public int maxDurability;

}
