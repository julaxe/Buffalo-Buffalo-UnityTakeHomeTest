using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace _Scripts.Units
{
    public sealed class SpawnPointContinuosly : MonoBehaviour
    {
        [SerializeField] private List<ScriptableEnemy> enemiesToSpawn = new List<ScriptableEnemy>();
        [SerializeField] private float spawnRateScale = 1.0f;

        private HashSet<ScriptableEnemy> enemyBeingSpawned = new HashSet<ScriptableEnemy>();

        
        private void Update()
        {
            foreach (var enemy in enemiesToSpawn)
            {
                StartCoroutine(SpawnEnemyCoroutine(enemy));
            }
        }
        

        private IEnumerator SpawnEnemyCoroutine(ScriptableEnemy e)
        {
            if (enemyBeingSpawned.Contains(e)) yield break;
            enemyBeingSpawned.Add(e);
            yield return new WaitForSeconds(e.BaseStats.SpawnRate * spawnRateScale);
            Instantiate(e.Prefab, Vector3.zero, Quaternion.identity);
            enemyBeingSpawned.Remove(e);
        }
        
    }
}