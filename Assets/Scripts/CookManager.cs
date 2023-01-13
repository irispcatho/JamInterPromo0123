using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;
using DG.Tweening;
using UnityEngine.Serialization;

public class CookManager : MonoBehaviour
{
    [Header("Cook Intervention")] 
    [SerializeField] private float _timeBetweenAttackFood;
    [SerializeField] private float _timeBetweenAttackFork;
    [SerializeField] private Transform _cook;
    [SerializeField] private float _cookSpeed;
    [SerializeField] private float _cookWaitToAttack;
    [SerializeField] private ForkIntervention ForkIntervention;
    private bool _canSpawnFork;
    private bool _cookIsReady;
    private CookState _currentState;
    private Vector3 _cookInitPos;
    private GameObject _foodToDestroy;

    private void Start()
    {
        _currentState = CookState.Neutral;
        // 0 for Food - 1 for Fork
        StartCoroutine(LaunchCookIntervention(5, 0));
        StartCoroutine(LaunchCookIntervention(7, 1));
        _cookInitPos = _cook.position;
    }

    private IEnumerator LaunchCookIntervention(float timer, int attack)
    {
        yield return new WaitForSeconds(timer);
        switch (attack)
        {
            case 0:
                // Food
                CookIntervention();
                break;
            case 1:
                // Fork
                CookForkIntervention();
                break;
        }   
    }

    private void CookIntervention()
    {
        int random = Random.Range(0, PatternManager.Instance._foodInGame.Count);
        GameObject foodKey = PatternManager.Instance._foodInGame.ElementAt(random).Key;
        Vector3 endPos = foodKey.transform.position;

        _currentState = CookState.MoveX;
        _cook.position = new Vector3(endPos.x, _cook.position.y, _cook.position.z);

        _currentState = CookState.MoveZ;
        
        float distanceZ = Vector3.Distance(_cook.position, endPos);
        _foodToDestroy = foodKey;

        _cook.DOKill();
        _cook.DOMoveZ(endPos.z, distanceZ / _cookSpeed).OnComplete(CookWait);

        Vector2Int foodValue = PatternManager.Instance._foodInGame.ElementAt(random).Value;
        GridManager.Instance._grid[foodValue.x, foodValue.y] = null;
        PatternManager.Instance._foodInGame.Remove(foodKey);
        PatternManager.Instance.UpdateOnCurrentGame();
    }

    private void CookWait()
    {
        AudioManager.Instance.PlaySound("Spatule");
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
        StartCoroutine(LaunchCookIntervention(PatternManager.Instance._currentLevel._waitForCook, 0));
    }

    // Fork
    private void CookForkIntervention()
    {
        ForkIntervention.ChooseForkIntervention();
        _canSpawnFork = true;
    }

    private void Update()
    {
        if (_canSpawnFork)
        {
            _canSpawnFork = false;
            StartCoroutine(LaunchCookIntervention(_timeBetweenAttackFork, 1));
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


