using System;
using UnityEngine;

public abstract class ScriptableUnitBase : ScriptableObject
{

    public string Name;
    
    [SerializeField] private Stats _stats;
    public Stats BaseStats => _stats;

    // Used in game
    public UnitBase Prefab;
    
    // Used in menus
    public string Description;
}

[Serializable]
public struct Stats {
    public int AttackPower;
    public int Health;
    public int Speed;
    public float SpawnRate;
}
