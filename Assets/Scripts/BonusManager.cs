using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusManager : MonoBehaviour
{
    // Variables GD
    [Header("Variables")]
    public GameObject[] PositionList;
    private GameObject _currentPosition;

    // Timer
    private float _time;

    // Reference
    public GameplayVariable Gameplay;
    public FoodBonus Bonus;



    private void Update()
    {
        Timer();
    }

    private void Timer()
    {
        _time += Time.deltaTime;

        if (_time >= Gameplay.SpawnTime)
        {
            // Reset Timer
            _time = 0.0f;

            // Change CurrentPosition
            
            _currentPosition = PositionList[Random.Range(0, PositionList.Length)];
           
            // Spawn Bonus
            if (GameObject.FindObjectOfType<FoodBonus>() == null)
            {
                SpawnBonus();
            }
        }
    }

    private void SpawnBonus()
    {
        Instantiate(Bonus, _currentPosition.transform.position, Quaternion.identity);
    }
}
