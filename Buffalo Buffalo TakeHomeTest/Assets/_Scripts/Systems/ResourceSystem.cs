using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// One repository for all scriptable objects. Create your query methods here to keep your business logic clean.
/// I make this a MonoBehaviour as sometimes I add some debug/development references in the editor.
/// If you don't feel free to make this a standard class
/// </summary>
public class ResourceSystem : StaticInstance<ResourceSystem> {
    public List<ScriptableEnemy> Enemies { get; private set; }
    private Dictionary<string, ScriptableEnemy> _ExampleHeroesDict;

    protected override void Awake() {
        base.Awake();
        AssembleResources();
    }

    private void AssembleResources() {
        Enemies = Resources.LoadAll<ScriptableEnemy>("Enemies").ToList();
        _ExampleHeroesDict = Enemies.ToDictionary(r => r.Name, r => r);
    }

    public ScriptableEnemy GetEnemy(string enemyName) => _ExampleHeroesDict[enemyName];
    public ScriptableEnemy GetRandomHero() => Enemies[Random.Range(0, Enemies.Count)];
}   