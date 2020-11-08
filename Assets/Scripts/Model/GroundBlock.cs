using System;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.Model
{
    public class GroundBlock
    {
        public IObservable<Unit> OnDestroyed => onDestroyed;
        public ReactiveProperty<GroundBlockState> State { get; } = new ReactiveProperty<GroundBlockState>();
        public Vector2 Pos { get; }

        readonly Subject<Unit> onDestroyed = new Subject<Unit>();

        public GroundBlock(Vector2 pos)
        {
            Pos = pos;
            State.Value = GroundBlockState.None;
        }

        public void Destroy()
        {
            onDestroyed.OnNext(default);
        }
    }

    public enum GroundBlockState
    {
        None,
        Growth1,
        Growth2,
        Growth3
    }
}