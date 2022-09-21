using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Scriptables
{
    [CreateAssetMenu( menuName = "Scriptable/DayCycleSettings")]
    public class ScriptableDayCycleSettings : ScriptableObject
    {
        public List<ScriptableEnemyStatsChanges> actions;
    }
}