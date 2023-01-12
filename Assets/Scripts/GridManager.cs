using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;
using DG.Tweening;

public class GridManager : MonoBehaviour
{
    [Header("Cook Intervention")] [SerializeField]
    private float _timeBetweenIntervention;

    [SerializeField] private Transform _cook;
    [SerializeField] private float _cookSpeed;
    [SerializeField] private float _cookWaitToAttack;
    private bool _cookIsReady;

    [Header("Grid")] public Transform _ground;
    public Transform _minPos;
    public int _width;
    public int _height;
    public float _cellSize;

    public Food[,] _grid;

    private PatternManager _pm;
    private GameObject _foodToDestroy;
    private Vector3 _cookInitPos;
    private float _timer;

    private CookState _currentState;

    private void Awake()
    {
        _pm = gameObject.GetComponent<PatternManager>();
    }

    private void Start()
    {
        _grid = new Food[_width, _height];
        _pm.SpawnNewPattern(0);
        _currentState = CookState.Neutral;
        StartCoroutine(LaunchCookIntervention());
        _cookInitPos = _cook.position;
    }

    public Vector3 GetWorldPosition(int xGrid, int yGrid)
    {
        Vector3 position = _minPos.position + _cellSize * xGrid * Vector3.right + _cellSize / 2 * Vector3.right +
                           _cellSize * yGrid * Vector3.forward + _cellSize / 2 * Vector3.forward;
        return position;
    }

    public IEnumerator LaunchCookIntervention()
    {
        yield return new WaitForSeconds(_timeBetweenIntervention);
        CookIntervention();
    }

    private void CookIntervention()
    {
        int random = Random.Range(0, _pm._foodInGame.Count);
        GameObject foodKey = _pm._foodInGame.ElementAt(random).Key;
        Vector3 endPos = foodKey.transform.position;

        _currentState = CookState.MoveX;
        _cook.position = new Vector3(endPos.x, _cook.position.y, _cook.position.z);

        _currentState = CookState.MoveZ;
        
        float distanceZ = Vector3.Distance(_cook.position, endPos);
        _foodToDestroy = foodKey;

        _cook.DOKill();
        _cook.DOMoveZ(endPos.z, distanceZ / _cookSpeed).OnComplete(CookWait);

        _pm._foodInGame.Remove(foodKey);
    }

    private void CookWait()
    {
        _currentState = CookState.Waiting;
        StartCoroutine((CookWaitCoroutine()));
    }

    private IEnumerator CookWaitCoroutine()
    {
        yield return new WaitForSeconds(_cookWaitToAttack);
        CookGoBack();
    }

    private void CookGoBack()
    {
        _currentState = CookState.BackZ;
        
        Destroy(_foodToDestroy);
        float distance = Vector3.Distance(_cook.position, _cookInitPos);
        _cook.DOKill();
        _cook.DOMoveZ(_cookInitPos.z, distance / _cookSpeed).OnComplete(CookInit);
    }

    private void CookInit()
    {
        _currentState = CookState.Neutral;
        StartCoroutine(LaunchInterventionAgain());
    }

    private IEnumerator LaunchInterventionAgain()
    {
        yield return new WaitForSeconds(_timeBetweenIntervention);
        CookIntervention();
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

public enum CookState
{
    Neutral,
    MoveX,
    MoveZ,
    Waiting,
    BackZ
}