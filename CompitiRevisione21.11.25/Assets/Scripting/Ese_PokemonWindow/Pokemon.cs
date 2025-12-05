using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pokemon", menuName = "Scriptable Objects/Pokemon")]
public class Pokemon : ScriptableObject
{
    public string Name;
    public List<Attribute> Attributes = new List<Attribute>();
    public PokemonStats Stats;
    public string[] Moves = new string[4];
    public Sprite Icon;



}
