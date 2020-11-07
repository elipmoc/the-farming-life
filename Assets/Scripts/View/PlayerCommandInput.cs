using System;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.View
{
    public class PlayerCommandInput : MonoBehaviour
    {
        public struct ClickInfo
        {
            public Vector2 Pos;
        }

        public IObservable<ClickInfo> OnRightClicked => onRightClicked;
        public IObservable<ClickInfo> OnLeftClicked => onLeftClicked;

        readonly Subject<ClickInfo> onRightClicked = new Subject<ClickInfo>();
        readonly Subject<ClickInfo> onLeftClicked = new Subject<ClickInfo>();

        void Start()
        {
            this.ObserveEveryValueChanged(_ => Input.GetMouseButton(0))
                .Where(isDown => isDown)
                .Subscribe(_ => onLeftClicked.OnNext(GetMousePosition()));

            this.ObserveEveryValueChanged(_ => Input.GetMouseButton(1))
                .Where(isDown => isDown)
                .Subscribe(_ => onRightClicked.OnNext(GetMousePosition()));

        }

        ClickInfo GetMousePosition()
        {
            var pos = Input.mousePosition;
            return new ClickInfo { Pos = Camera.main.ScreenToWorldPoint(pos) };
        }
    }
}