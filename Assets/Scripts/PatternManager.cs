using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PatternManager : MonoBehaviour
{
    [SerializeField] private List<Level> _levels = new List<Level>();
    private List<Food> _foodInGame = new List<Food>();
    private GridManager _gm;

    private void Awake()
    {
        _gm = gameObject.GetComponent<GridManager>();
    }

    public void SpawnNewPattern(int level)
    {
        int random = Random.Range(0, _levels[level]._patterns.Count);
        Debug.Log(random);
        foreach (Food food in _levels[level]._patterns[random]._foods)
        {
            _gm._grid[food._gridPosition.x, food._gridPosition.y] = food;

            Vector3 position = _gm.GetWorldPosition(food._gridPosition.x, food._gridPosition.y) + (Vector3)food._offset;
            GameObject obj = Instantiate(food._object, position, Quaternion.identity, transform);

            food.Fall(obj, _gm._ground.position.y + 0.5f);
            
            _foodInGame.Add(food);
        }
    }
}