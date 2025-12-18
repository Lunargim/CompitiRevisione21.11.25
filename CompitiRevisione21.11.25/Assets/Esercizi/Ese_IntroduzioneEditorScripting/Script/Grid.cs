using UnityEngine;

[CreateAssetMenu(fileName = "Grid", menuName = "Scriptable Objects/Grid")]
public class Grid : ScriptableObject
{
    public float _gridCellSize;
    public Vector2Int _gridSize;
}
