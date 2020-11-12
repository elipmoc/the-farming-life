using Assets.Scripts.Constants;
using System;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.Model
{

    public class Ground
    {
        readonly GroundBlock[,] groundBlocks;

        public IObservable<GroundBlock> OnCreatedGround => onCreatedGround;
        public IObservable<Unit> OnSeeded => onSeeded;

        readonly Subject<GroundBlock> onCreatedGround = new Subject<GroundBlock>();
        readonly Subject<Unit> onSeeded = new Subject<Unit>();

        public Ground()
        {
            groundBlocks = new GroundBlock[GroundConstant.FIELD_LENGTH, GroundConstant.FIELD_LENGTH];
        }

        public void Plow(Vector2 pos)
        {
            if (GroundGridService.IsOverflowFieldRange(pos) || ContainsGroundBlock(pos))
                return;

            var groundBlock = new GroundBlock(GroundGridService.ToGroundGridPosition(pos));
            SetGroundBlock(groundBlock);
            onCreatedGround.OnNext(groundBlock);
        }

        public void Seed(Vector2 pos)
        {
            if (GroundGridService.IsOverflowFieldRange(pos) || ContainsGroundBlock(pos) == false)
                return;

            GetGroundBlock(pos).State.Value = GroundBlockState.Growth1;
            onSeeded.OnNext(default);
        }

        private bool ContainsGroundBlock(Vector2 pos)
        {
            return GetGroundBlock(pos) != null;
        }

        private GroundBlock GetGroundBlock(Vector2 pos)
        {
            return
                groundBlocks[
                    GroundGridService.ToGroundGridCountWithLeftDownBased(pos.x),
                    GroundGridService.ToGroundGridCountWithLeftDownBased(pos.y)
                ];
        }

        private void SetGroundBlock(GroundBlock groundBlock)
        {
            groundBlocks[
                GroundGridService.ToGroundGridCountWithLeftDownBased(groundBlock.Pos.x),
                GroundGridService.ToGroundGridCountWithLeftDownBased(groundBlock.Pos.y)
            ] = groundBlock;
        }
    }
}
