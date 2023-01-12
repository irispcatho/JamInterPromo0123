using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkSpawner : MonoBehaviour
{
    //Variables du spawner : 
    //-Direction dans laquelle lancer la fourchette

    //Variable de l’intervention : 

    //-Les différents spawner
    //-La vitesse de la fourchette
    //-Le temps pour passer de l’état armée à l’état tiré
    //-Le nombre de fourchettes lancée

    // Set Fork Speed to created instance

    // GD Variables
    [Header("Variables")]
    public GameObject ForkPrefab;
    public int ForkNumber = 1;
    public float ForkSpeed = 1;
    public GameObject[] PositionList;
    public GameObject CurrentSpawnerPosition;

    // Time
    private float _time;
    public float ForkSpawnTime;

    private void Update()
    {
        Timer();
    }

    private void Timer()
    {
        _time += Time.deltaTime;

        if (_time >= ForkSpawnTime)
        {
            // Reset Timer
            _time = 0.0f;

            // Change CurrentPosition

            CurrentSpawnerPosition = PositionList[Random.Range(0, PositionList.Length)];

            // Spawn Fork
            SpawnFork();
        }
    }

    private void SpawnFork()
    {
        Instantiate(ForkPrefab, CurrentSpawnerPosition.transform.position, CurrentSpawnerPosition.transform.rotation);
    }
}
