using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Level : ScriptableObject
{
    public List<Pattern> _patterns = new List<Pattern>();
    public int _foodQuantityForNextPattern;
    public int _foodQuantityForNextLevel;
}