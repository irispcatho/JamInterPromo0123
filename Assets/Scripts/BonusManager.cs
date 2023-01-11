using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusManager : MonoBehaviour
{
    // Variables GD
    [Header("Variables")]
    private Vector3 CurrentPosition;

    // Timer
    private float time;

    // Reference
    public GameplayVariable Gameplay;
    public FoodBonus Bonus;



    private void Update()
    {
        Timer();
    }

    private void Timer()
    {
        time += Time.deltaTime;

        if (time >= Gameplay.SpawnTime)
        {
            // Reset Timer
            time = 0.0f;

            // Change CurrentPosition
            CurrentPosition = Gameplay.PositionList[Random.Range(0, Gameplay.PositionList.Length)];

            // Spawn Bonus
            SpawnBonus();
        }
    }

    private void SpawnBonus()
    {
        Instantiate(Bonus, CurrentPosition, Quaternion.identity);
    }
}
