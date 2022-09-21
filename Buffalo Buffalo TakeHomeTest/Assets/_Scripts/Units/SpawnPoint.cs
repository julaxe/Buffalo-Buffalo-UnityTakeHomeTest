using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Scripts.Units
{
    public class SpawnPoint : MonoBehaviour
    {
        //reference to the scriptable objects with the enemy info
        [SerializeField] private List<ScriptableEnemy> enemiesToSpawn = new List<ScriptableEnemy>();
        
        //Gizmos color
        [SerializeField] private Color gizmosColor;

        //current stats of the enemies depending of the time.
        private List<EnemyUnitBase> enemies;

        private void Awake()
        {
            GameManager.OnBeforeStateChanged += ResetEnemiesToBaseStats;
            GameManager.OnAfterStateChanged += OnChangeDayCycle;
        }

        private void Start()
        {
            CreateEnemiesWithBaseStats();
        }

        private void CreateEnemiesWithBaseStats()
        {
            enemies = new List<EnemyUnitBase>();
            foreach (var enemy in enemiesToSpawn)
            {
                var temp = Instantiate(enemy.Prefab, transform);
                temp.gameObject.SetActive(false);
                temp.SetEnemyBaseStats(enemy);
                enemies.Add(temp);
            }
        }

        private void ResetEnemiesToBaseStats(DayCycle cycle)
        {
            foreach (var enemy in enemies)
            {
                enemy.ResetStats();
            }
        }
        private void OnChangeDayCycle(DayCycle cycle)
        {
            var currentDayCycleSettings = GameManager.Instance.GetDayCycleSettings();
            foreach (var action in currentDayCycleSettings.actions)
            {
                foreach (var enemy in enemies)
                {
                    enemy.ApplyStatsChanges(action);
                }
            }
           
            //spawn a new enemy
            SpawnEnemyFromList();
        }

        private void SpawnEnemyFromList()
        {
            //get total spawnRate
            float totalSpawnRate = 0;
            enemies.ForEach(enemy => totalSpawnRate += enemy.Stats.SpawnRate);
            //do a random from 0 to totalSpawnRate
            float randomSpawnRate = Random.Range(0.0f, totalSpawnRate);
            
            //go through list an spawns the enemy in between that random number
            float currentSpawnRate = 0.0f;
            foreach (var enemy in enemies)
            {
                if (randomSpawnRate >= currentSpawnRate && randomSpawnRate < currentSpawnRate + enemy.Stats.SpawnRate)
                {
                    var newEnemy = Instantiate(enemy, transform);
                    newEnemy.gameObject.SetActive(true);
                    break;
                }
                currentSpawnRate += enemy.Stats.SpawnRate;
            }

        }

        private void OnDrawGizmos()
        {
            Gizmos.color = gizmosColor;
            Gizmos.DrawWireSphere(transform.position, 1.0f);
        }
    }
}