using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBonus : MonoBehaviour
{

    // Variables GD
    [Header("Variables")]
    public int Points;

    // Reference
    [Header("Reference")]
    public ScoreManager ScoreManager;


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ScoreManager.AddScore(Points);
            Destroy(gameObject);
        }

    }
}
