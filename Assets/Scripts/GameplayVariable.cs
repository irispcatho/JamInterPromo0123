using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu]
public class GameplayVariable : ScriptableObject
{
    [Header("Plancha Variables")]
    public float GaugeOnPlanchaSpeed = 20;
    public float GaugeSafeZoneSpeed = 3;

    [Header("Bonus Variables")]
    public int Points = 5;
    public int DestroyTime = 5;

    [Header("Bonus Spawner")]
    public float SpawnTime = 1;
}
