using UnityEngine;


public class UnitBase : MonoBehaviour
{
    private Stats Stats;
    public virtual void SetStats(Stats stats) => Stats = stats;
    public virtual void TakeDamage(int dmg) {
        
    }
}