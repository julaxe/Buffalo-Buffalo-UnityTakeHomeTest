using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : StaticInstance<GameManager> {
    public static event Action<DayCycle> OnBeforeStateChanged;
    public static event Action<DayCycle> OnAfterStateChanged;

    public DayCycle DayCycle { get; private set; }

    // Kick the game off with the first state
    void Start()
    {
        ChangeDayCycle((DayCycle)Random.Range(0,2));
    }

    public void ChangeDayCycle(DayCycle newState) {
        OnBeforeStateChanged?.Invoke(newState);

        DayCycle = newState;
        switch (newState) {
            case DayCycle.Morning:
                HandleMorning();
                break;
            case DayCycle.Afternoon:
                break;
            case DayCycle.Night:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnAfterStateChanged?.Invoke(newState);
        
        Debug.Log($"New state: {newState}");
    }

    private void HandleMorning() {
        // Do some start setup, could be environment, cinematics etc
        UnitManager.Instance.SpawnRedEnemy();
        // Eventually call ChangeState again with your next state

        //ChangeState(GameState.SpawningHeroes);
    }
    
}

[Serializable]
public enum DayCycle {
    Morning = 0,
    Afternoon,
    Night
}