using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkSpawner : MonoBehaviour
{
    // GD Variables
    [Header("Variables")]
    public int ForkNumber = 1;
    public float ForkSpeed = 1;
    public GameObject[] PositionList;
    public float FeedbackDisappearTime;
    public float ForkAppearTime;


    [Header("References")]
    public GameObject CurrentSpawnerPosition;
    public GameObject ForkPrefab;
    public GameObject FeedbackLine;

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

            // Start Fork Spawn Process
            Spawn(FeedbackLine);

            // Wait Some Time and Spawn Fork
            StartCoroutine(SpawnFork());
        }
    }

    private void Spawn(GameObject _spawnedObject)
    {
        var spawnFeedback = Instantiate(_spawnedObject, CurrentSpawnerPosition.transform.position, CurrentSpawnerPosition.transform.rotation);

        // If Spawned Object is not a Fork
        if (_spawnedObject.GetComponent<ForkBehavior>() == null)
            Destroy(spawnFeedback, FeedbackDisappearTime);
    }

    private IEnumerator SpawnFork()
    {
        yield return new WaitForSeconds(ForkAppearTime);

        // Spawn Fork
        Spawn(ForkPrefab);
    }
}
