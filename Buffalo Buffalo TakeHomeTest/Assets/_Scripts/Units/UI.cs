using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Units
{
    public class UI : MonoBehaviour
    {
        [SerializeField] private Button morningButton;
        [SerializeField] private Button afternoonButton;
        [SerializeField] private Button nightButton;
        [SerializeField] private TextMeshProUGUI currentDayCycleText;

        private void Awake()
        {
            GameManager.OnAfterStateChanged += OnDayCycleChange;
        }

        private void Start()
        {
            morningButton.onClick.AddListener(() =>
            {
                GameManager.Instance.ChangeDayCycle(DayCycle.Morning);
            });
            afternoonButton.onClick.AddListener(() =>
            {
                GameManager.Instance.ChangeDayCycle(DayCycle.Afternoon);
            });
            nightButton.onClick.AddListener(() =>
            {
                GameManager.Instance.ChangeDayCycle(DayCycle.Night);
            });
        }

        private void OnDayCycleChange(DayCycle dayCycle)
        {
            switch (dayCycle)
            {
                case DayCycle.Morning:
                    currentDayCycleText.text = "Morning";
                    break;
                case DayCycle.Afternoon:
                    currentDayCycleText.text = "Afternoon";
                    break;
                case DayCycle.Night:
                    currentDayCycleText.text = "Night";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(dayCycle), dayCycle, null);
            }
        }
    }
}