using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkBehavior : MonoBehaviour
{
    [Header("Variables")]
    public float Speed;
    private int _destroyTime = 10;
    public ForkSpawner ForkSpawner;

    private void Awake()
    {
        ForkSpawner = FindObjectOfType<ForkSpawner>();
        Destroy(gameObject, _destroyTime);
        Speed = ForkSpawner.ForkSpeed;
    }

    private void Update()
    {
        transform.position += transform.forward * Time.deltaTime * Speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Player Death
            Debug.Log("Death");
        }
    }
}
