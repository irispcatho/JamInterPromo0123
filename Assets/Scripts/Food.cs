using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

[Serializable]
public struct Food
{
    public GameObject _object;
    public Vector2Int _gridPosition;
    public Vector2 _offset;
    public float _fallTime;

    public void Fall(GameObject obj, float yPos)
    {
        obj.transform.DOMoveY(yPos, _fallTime).OnComplete(SoundOn);
    }

    private void SoundOn()
    {
        AudioManager.Instance.PlaySound("Food");
    }
}
