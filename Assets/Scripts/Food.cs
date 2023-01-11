using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Food
{
    public GameObject _object;
    public Vector2Int _gridPosition;
    public Vector2 _offset;
}
