using Assets.Scripts.Constants;
using UnityEngine;

namespace Assets.Scripts.View
{
    class BaseGroundView : MonoBehaviour
    {
        [SerializeField]
        SpriteRenderer groundPrefab = null;

        void Start()
        {
            var groundsSprites = Resources.LoadAll<Sprite>("Textures/grounds");

            for (int x = -GroundConstant.FIELD_RANGE; x <= GroundConstant.FIELD_RANGE; x++)
            {
                for (int y = -GroundConstant.FIELD_RANGE; y <= GroundConstant.FIELD_RANGE; y++)
                {
                    var ground = Instantiate(groundPrefab, transform);
                    ground.sprite = groundsSprites[Random.Range(0, groundsSprites.Length)];
                    ground.transform.position = new Vector2(x, y) * GroundConstant.GROUND_SIZE;
                }
            }
        }
    }
}
