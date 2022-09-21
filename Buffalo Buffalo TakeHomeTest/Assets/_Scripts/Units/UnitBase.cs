using System;
using UnityEngine;


public class UnitBase : MonoBehaviour
{
    public Stats Stats { get; protected set; }

    public virtual void SetStats(Stats stats) => Stats = stats;
    public virtual void TakeDamage(int dmg) {
        
    }
}