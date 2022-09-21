using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/Units/Enemy")]
public class ScriptableEnemy : ScriptableUnitBase 
{
    public EnemyClass Class;
    // Used in game
    public EnemyUnitBase Prefab;
}

[Flags]
public enum EnemyClass 
{
    Grunts=1,
    Archer=2,
    Assassin=4
}

