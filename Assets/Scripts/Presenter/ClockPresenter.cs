using System;
using Assets.Scripts.Model;
using Assets.Scripts.View;
using UnityEngine;
using UniRx;

namespace Assets.Scripts.Presenter
{
    public class ClockPresenter : MonoBehaviour
    {
        [SerializeField]
        ClockView clockView = null;

        readonly Clock clock = new Clock();

        void Awake()
        {
            Observable
                .Timer(TimeSpan.Zero, TimeSpan.FromSeconds(1))
                .Subscribe(_ =>
                {
                    clock.CountMinutes();
                    clockView.SetTime(clock.hours, clock.minutes);
                });
        }
    }
}
