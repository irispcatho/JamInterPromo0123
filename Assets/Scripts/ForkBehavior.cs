using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkBehavior : MonoBehaviour
{
    [Header("Variables")]
    public float Speed;
    private int _destroyTime = 10;
    private int _unitCorrection = 100;

    private void Start()
    {
        Destroy(gameObject, _destroyTime);
    }

    private void Update()
    {
        gameObject.transform.position += new Vector3(0, 0, Speed/_unitCorrection);
    }
}
