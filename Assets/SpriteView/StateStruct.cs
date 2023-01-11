using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class State
{
    public string Name;
    
    [Range(0, 1)] 
    public float TimeBetweenFrames;
    
    public List<Sprite> SpriteSheet;
}

