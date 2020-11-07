using Assets.Scripts.Constants;
using UnityEngine;

namespace Assets.Scripts.Model
{
    public static class GroundGridService
    {
        public static bool IsOverflowFieldRange(Vector2 pos)
        {
            return
                pos.x < -GroundConstant.FIELD_RANGE * GroundConstant.GROUND_SIZE - GroundConstant.GROUND_SIZE / 2 ||
                pos.x > GroundConstant.FIELD_RANGE * GroundConstant.GROUND_SIZE + GroundConstant.GROUND_SIZE / 2 ||
                pos.y < -GroundConstant.FIELD_RANGE * GroundConstant.GROUND_SIZE - GroundConstant.GROUND_SIZE / 2 ||
                pos.y > GroundConstant.FIELD_RANGE * GroundConstant.GROUND_SIZE + GroundConstant.GROUND_SIZE / 2;
        }

        public static Vector2 ToGroundGridPosition(Vector2 pos)
        {
            return new Vector2(ToGroundGridPosition(pos.x), ToGroundGridPosition(pos.y));
        }

        public static float ToGroundGridPosition(float v)
        {
            return ToGroundGridCount(v) * GroundConstant.GROUND_SIZE;
        }

        public static int ToGroundGridCountWithLeftDownBased(float v)
        {
            return ToGroundGridCount(v) + GroundConstant.FIELD_RANGE;
        }

        public static int ToGroundGridCount(float v)
        {
            return Mathf.RoundToInt(v / GroundConstant.GROUND_SIZE);
        }
    }
}
