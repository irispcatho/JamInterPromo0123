using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class PatternManager : MonoBehaviour
{
    public static PatternManager Instance;

    [SerializeField] private List<Level> _levels = new List<Level>();
    public Dictionary<GameObject, Vector2Int> _foodInGame = new Dictionary<GameObject, Vector2Int>();
    private GridManager _gm;

    public Level _currentLevel;
    private int _patternsAlreadyDone;

    private void Awake()
    {
        Instance = this;
        _gm = gameObject.GetComponent<GridManager>();
    }

    private void Start()
    {
        _currentLevel = _levels[0];
        StartCoroutine(SpawnNewPattern(0));
    }

    public IEnumerator SpawnNewPattern(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        int random = Random.Range(0, _levels[_currentLevel.index]._patterns.Count);
        Debug.Log(random);

        for (int index = 0; index < _levels[_currentLevel.index]._patterns[random]._foods.Count; index++)
        {
            Food food = _levels[_currentLevel.index]._patterns[random]._foods[index];

            if (_gm._grid[food._gridPosition.x, food._gridPosition.y] != null) continue;

            Vector3 position = _gm.GetWorldPosition(food._gridPosition.x, food._gridPosition.y) +
                               (Vector3)food._offset;
            GameObject obj = Instantiate(food._object, position, Quaternion.identity, transform);

            _gm._grid[food._gridPosition.x, food._gridPosition.y] = obj;

            food.Fall(obj, _gm._ground.position.y + 0.5f);
            _foodInGame.Add(obj, food._gridPosition);
        }

        _patternsAlreadyDone++;
    }

    public void UpdateOnCurrentGame()
    {
        if (_foodInGame.Count <= _currentLevel._foodQuantityForNextPattern)
        {
            StartCoroutine(SpawnNewPattern(5));
        }

        if (_foodInGame.Count <= _currentLevel._foodQuantityForNextPattern &&
            _patternsAlreadyDone >= _currentLevel._patternQuantityForNextLevel &&
            _currentLevel.index < _levels.Count - 1)
        {
            _currentLevel = _levels[_currentLevel.index + 1];
            _patternsAlreadyDone = 0;
        }
    }
}