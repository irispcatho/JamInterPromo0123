using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkBehavior : MonoBehaviour
{
    [Header("Variables")]
    public float Speed;
    private int _destroyTime = 10;
    private int _unitCorrection = 100;
    public ForkSpawner ForkSpawner;
    private Vector3 direction;

    private void Awake()
    {
        ForkSpawner = FindObjectOfType<ForkSpawner>();
        Destroy(gameObject, _destroyTime);
    }

    private void Update()
    {
        transform.position += transform.forward * Time.deltaTime * Speed;
    }
}
