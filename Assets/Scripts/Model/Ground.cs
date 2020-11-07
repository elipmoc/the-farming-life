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

        readonly Subject<GroundBlock> onCreatedGround = new Subject<GroundBlock>();

        public Ground()
        {
            groundBlocks = new GroundBlock[GroundConstant.FIELD_LENGTH, GroundConstant.FIELD_LENGTH];
        }

        public void OnPlowed(Vector2 pos)
        {
            if (GroundGridService.IsOverflowFieldRange(pos) || ContainsGroundBlock(pos))
                return;

            var groundBlock = new GroundBlock(GroundGridService.ToGroundGridPosition(pos));
            SetGroundBlock(groundBlock);
            onCreatedGround.OnNext(groundBlock);
        }

        private bool ContainsGroundBlock(Vector2 pos)
        {
            return
                groundBlocks[
                    GroundGridService.ToGroundGridCountWithLeftDownBased(pos.x),
                    GroundGridService.ToGroundGridCountWithLeftDownBased(pos.y)
                ] != null;
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
