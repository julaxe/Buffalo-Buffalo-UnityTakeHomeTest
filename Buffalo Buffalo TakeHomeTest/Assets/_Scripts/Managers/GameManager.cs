using System;
using _Scripts.Scriptables;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : StaticInstance<GameManager> {
    public static event Action<DayCycle> OnBeforeStateChanged;
    public static event Action<DayCycle> OnAfterStateChanged;


    //Day Cycle variables
    public DayCycle DayCycle { get; private set; }
    [SerializeField] private ScriptableDayCycleSettings morningSettings;
    [SerializeField] private ScriptableDayCycleSettings afternoonSettings;
    [SerializeField] private ScriptableDayCycleSettings nightSettings;
    private ScriptableDayCycleSettings currentDayCycleSettings;
    

    // Kick the game off with the first state
    void Start()
    {
        ChangeDayCycle((DayCycle)Random.Range(0,3));
    }

    public void ChangeDayCycle(DayCycle newState) 
    {
        OnBeforeStateChanged?.Invoke(newState);

        DayCycle = newState;
        switch (newState) {
            case DayCycle.Morning:
                HandleMorning();
                break;
            case DayCycle.Afternoon:
                HandleAfternoon();
                break;
            case DayCycle.Night:
                HandleNight();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnAfterStateChanged?.Invoke(newState);
        
        Debug.Log($"New state: {newState}");
    }

    private void HandleMorning()
    {
        currentDayCycleSettings = morningSettings;
    }
    private void HandleAfternoon() 
    {
        currentDayCycleSettings = afternoonSettings;
    }
    private void HandleNight() 
    {
        currentDayCycleSettings = nightSettings;
    }

    public ScriptableDayCycleSettings GetDayCycleSettings() => currentDayCycleSettings;

}

[Serializable]
public enum DayCycle {
    Morning = 0,
    Afternoon,
    Night
}