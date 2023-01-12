using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkIntervention : MonoBehaviour
{
    // GD Variables
    [Header("Variables")]
    public ForkSpawner[] ForkInterventionList;
    //public float InterventionTime;

    public void ChooseForkIntervention()
    {
        Instantiate(ForkInterventionList[Random.Range(0, ForkInterventionList.Length)], Vector3.zero, Quaternion.identity);
    }
}
