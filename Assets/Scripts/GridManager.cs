using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;
using DG.Tweening;

public class GridManager : MonoBehaviour
{
    [Header("Grid")] public Transform _ground;
    public Transform _minPos;
    public int _width;
    public int _height;
    public float _cellSize;

    public Food[,] _grid;

    private PatternManager _pm;
    private float _timer;

    private void Awake()
    {
        _pm = gameObject.GetComponent<PatternManager>();
    }

    private void Start()
    {
        _grid = new Food[_width, _height];
        _pm.SpawnNewPattern(0);
    }

    public Vector3 GetWorldPosition(int xGrid, int yGrid)
    {
        Vector3 position = _minPos.position + _cellSize * xGrid * Vector3.right + _cellSize / 2 * Vector3.right +
                           _cellSize * yGrid * Vector3.forward + _cellSize / 2 * Vector3.forward;
        return position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;

        for (int i = 0; i < _height + 1; i++)
        {
            Gizmos.DrawLine(_minPos.position + _cellSize * i * Vector3.forward,
                _minPos.position + _cellSize * i * Vector3.forward + Vector3.right * _width * _cellSize);
        }

        for (int i = 0; i < _width + 1; i++)
        {
            Gizmos.DrawLine(_minPos.position + _cellSize * i * Vector3.right,
                _minPos.position + _cellSize * i * Vector3.right + Vector3.forward * _height * _cellSize);
        }
    }
}