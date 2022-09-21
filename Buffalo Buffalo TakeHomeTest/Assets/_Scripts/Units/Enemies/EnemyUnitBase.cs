
using _Scripts.Scriptables;
using UnityEngine;

public class EnemyUnitBase : UnitBase
{
    private ScriptableEnemy EnemyBaseStats;

    public void SetEnemyBaseStats(ScriptableEnemy scriptableEnemy)
    {
        EnemyBaseStats = scriptableEnemy;
        Stats = scriptableEnemy.BaseStats;
    }

    public void ResetStats() => Stats = EnemyBaseStats.BaseStats;

    public void ApplyStatsChanges(ScriptableEnemyStatsChanges statsChanges)
    {
        if (statsChanges.TargetType == EnemyTargetType.ByClass &&
            !statsChanges.enemyClass.HasFlag(EnemyBaseStats.Class)) return;
        
        if (statsChanges.TargetType == EnemyTargetType.ByEnemy && !statsChanges.enemyScriptable.Equals(EnemyBaseStats))
            return;
        
        var stats = Stats;
        stats.Health += Random.Range(statsChanges.stats.Health.x,statsChanges.stats.Health.y+1);
        stats.AttackPower += Random.Range(statsChanges.stats.AttackPower.x,statsChanges.stats.AttackPower.y+1);
        stats.Speed += Random.Range(statsChanges.stats.Speed.x,statsChanges.stats.Speed.y+1);
        stats.SpawnRate += Random.Range(statsChanges.stats.SpawnRate.x,statsChanges.stats.SpawnRate.y+1) * 0.1f;

        if (stats.Health < 0) stats.Health = 0;
        if (stats.AttackPower < 0) stats.AttackPower = 0;
        if (stats.Speed < 0) stats.Speed = 0;
        if (stats.SpawnRate < 0) stats.SpawnRate = 0;
        
        SetStats(stats);
    }
}
