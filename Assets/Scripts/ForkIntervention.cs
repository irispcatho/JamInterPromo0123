using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkIntervention : MonoBehaviour
{
    // GD Variables
    [Header("Variables")]
    public ForkSpawner ForkSpawnerPrefab;
    public ForkSpawnerInformations[] ForkSpawnerInfos;
    //public float InterventionTime;

    public void ChooseForkIntervention()
    {
        var _createdSpawner = Instantiate(ForkSpawnerPrefab, Vector3.zero, Quaternion.identity);
        int _randomSpawner = Random.Range(0, ForkSpawnerInfos.Length);
        // Change Parameters
        _createdSpawner.ForkNumber = ForkSpawnerInfos[_randomSpawner].ForkNumber;
        _createdSpawner.ForkSpeed = ForkSpawnerInfos[_randomSpawner].ForkSpeed;
        _createdSpawner.PositionList = ForkSpawnerInfos[_randomSpawner].PositionList;
        _createdSpawner.FeedbackDisappearTime = ForkSpawnerInfos[_randomSpawner].FeedbackDisappearTime;
        _createdSpawner.ForkAppearTime = ForkSpawnerInfos[_randomSpawner].ForkAppearTime;
        _createdSpawner.ForksSpawnTime = ForkSpawnerInfos[_randomSpawner].ForksSpawnTime;
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        ChooseForkIntervention();
    //    }
    //}

    [System.Serializable]
    public struct ForkSpawnerInformations
    {
        [Header("Variables")]
        public int ForkNumber;
        public float ForkSpeed;
        public GameObject[] PositionList;
        public float FeedbackDisappearTime;
        public float ForkAppearTime;
        public float ForksSpawnTime;
    }
}
