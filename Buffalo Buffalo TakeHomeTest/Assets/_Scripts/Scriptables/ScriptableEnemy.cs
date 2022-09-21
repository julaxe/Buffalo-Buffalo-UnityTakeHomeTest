using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Unit/Enemy")]
public class ScriptableEnemy : ScriptableUnitBase {
    public EnemyClass Class;
}

[Serializable]
public enum EnemyClass {
    Grunt = 0,
    Archer,
    Assassin
}

