using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkSpawner : MonoBehaviour
{
    // GD Variables
    [Header("Variables")]
    public int ForkNumber;
    public float ForkSpeed;
    public GameObject[] PositionList;
    public float FeedbackDisappearTime;
    public float ForkAppearTime;
    public float ForksSpawnTime;


    [Header("References")]
    public GameObject CurrentSpawnerPosition;
    public GameObject ForkPrefab;
    public GameObject FeedbackLine;

    // Time
    private float _time;

    private void Update()
    {
        Timer();
    }

    private void Timer()
    {
        _time += Time.deltaTime;

        if (_time >= ForksSpawnTime)
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
        if (_spawnedObject.GetComponent<ForkBehavior>() == null) {

            spawnFeedback.transform.Rotate(-90,0,0);
            Destroy(spawnFeedback, FeedbackDisappearTime);
        }
    }

    private IEnumerator SpawnFork()
    {
        yield return new WaitForSeconds(ForkAppearTime);

        // Update Fork Number
        ForkNumber--;

        // Spawn Fork
        Spawn(ForkPrefab);

        // Destroy Spawner if no Forks Remaining
        if (ForkNumber <= 0)
            Destroy(gameObject);
    }
}
