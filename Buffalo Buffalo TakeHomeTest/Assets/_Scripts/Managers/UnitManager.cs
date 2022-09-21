using UnityEngine;

public class UnitManager : StaticInstance<UnitManager> {

    public void SpawnRedEnemy()
    {
        SpawnUnit("RedEnemy", Vector3.zero);
    }
    void SpawnUnit(string enemyName, Vector3 pos) {
        var tarodevScriptable = ResourceSystem.Instance.GetEnemy(enemyName);

        var spawned = Instantiate(tarodevScriptable.Prefab, pos, Quaternion.identity,transform);
        
        //modifications
        var stats = tarodevScriptable.BaseStats;

        spawned.SetStats(stats);
    }
}