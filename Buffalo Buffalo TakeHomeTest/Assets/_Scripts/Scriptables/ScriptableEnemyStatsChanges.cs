using System;
using UnityEngine;
using GD.MinMaxSlider;


#if UNITY_EDITOR
using UnityEditor;
#endif

namespace _Scripts.Scriptables
{
    [CreateAssetMenu(menuName = "Scriptable/DayCycleSettings/Actions")]
    public class ScriptableEnemyStatsChanges : ScriptableObject
    {
         public EnemyTargetType TargetType;
        [HideInInspector] public ScriptableEnemy enemyScriptable;
        [HideInInspector] public EnemyClass enemyClass;
        public RandomStats stats;
    }
    
    public enum EnemyTargetType
    {
        ByClass=1,
        ByEnemy=2
    }

    [Serializable]
    public struct RandomStats
    {
       [MinMaxSlider(-5,5)] public Vector2Int AttackPower;
       [MinMaxSlider(-5,5)] public Vector2Int Health;
       [MinMaxSlider(-5,5)] public Vector2Int Speed;
       [MinMaxSlider(-9,9)] public Vector2Int SpawnRate;
    }

    #region Editor
    #if UNITY_EDITOR
    [CustomEditor(typeof(ScriptableEnemyStatsChanges))]
    public class ScriptableEnemyStatsChangesEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            ScriptableEnemyStatsChanges enemyStatsChanges = (ScriptableEnemyStatsChanges) target;


            if (enemyStatsChanges.TargetType.HasFlag(EnemyTargetType.ByClass))
            {
                enemyStatsChanges.enemyClass = (EnemyClass)
                    EditorGUILayout.EnumFlagsField("Enemy Classes",enemyStatsChanges.enemyClass);
                //show multiple classes
            }
            else
            {
                enemyStatsChanges.enemyScriptable = EditorGUILayout.ObjectField("Enemy",enemyStatsChanges.enemyScriptable, typeof(ScriptableEnemy), true) as ScriptableEnemy;
            }
            

        }
    }
    
     #endif
     #endregion
}