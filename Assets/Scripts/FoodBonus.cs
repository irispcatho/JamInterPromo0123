using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBonus : MonoBehaviour
{

    // Variables GD
    [Header("Variables")]
    public GameplayVariable Gameplay;

    // Reference
    [Header("Reference")]
    public ScoreManager ScoreManager;

    private void Awake()
    {
        ScoreManager = FindObjectOfType<ScoreManager>();
        Destroy(gameObject, Gameplay.DestroyTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ScoreManager.AddScore(Gameplay.Points);
            Destroy(gameObject);
        }

    }
}
