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
    [SerializeField] private float _timeBetweenAttack;
    [SerializeField] private Transform _cook;
    [SerializeField] private float _cookSpeed;
    [SerializeField] private float _cookWaitToAttack;
    private bool _cookIsReady;
    private CookState _currentState;
    private Vector3 _cookInitPos;
    private GameObject _foodToDestroy;

    private void Start()
    {
        _currentState = CookState.Neutral;
        StartCoroutine(LaunchCookIntervention(6));
        _cookInitPos = _cook.position;
    }

    private IEnumerator LaunchCookIntervention(float timer)
    {
        yield return new WaitForSeconds(timer);
        CookIntervention();
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

        PatternManager.Instance._foodInGame.Remove(foodKey);
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
        StartCoroutine(LaunchCookIntervention(_timeBetweenAttack));
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
