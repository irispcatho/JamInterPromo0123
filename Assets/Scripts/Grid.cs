using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Grid : MonoBehaviour
{
    [SerializeField] private Transform _ground;
    [SerializeField] private Transform _minPos;
    [SerializeField] private int _width;
    [SerializeField] private int _height;
    [SerializeField] private float _cellSize;

    [SerializeField] private List<Food> _food = new List<Food>();
    private Food[,] _grid;

    void Start()
    {
        _grid = new Food[_width, _height];

        for (int i = 0; i < _food.Count; i++)
        {
            if (_food[i]._gridPosition.x < 0 || _food[i]._gridPosition.x >= _width || _food[i]._gridPosition.y < 0 ||
                _food[i]._gridPosition.y >= _height)
            {
                Debug.LogError("Coordinates are off the grid ! ");
            }
            
            _grid[_food[i]._gridPosition.x, _food[i]._gridPosition.y] = _food[i];

            Vector3 position = GetWorldPosition(_food[i]._gridPosition.x, _food[i]._gridPosition.y) + (Vector3)_food[i]._offset;

            GameObject obj = Instantiate(_food[i]._object, position, Quaternion.identity, transform);

            _food[i].Fall(obj, _ground.position.y + 0.5f);
        }
    }

    private Vector3 GetWorldPosition(int xGrid, int yGrid)
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