using Assets.Scripts.Model;
using UnityEngine;

namespace Assets.Scripts.View
{
    public class GroundsView : MonoBehaviour
    {
        [SerializeField]
        PlowedSoilView plowedSoilPrefab = null;

        public void PutPlowedSoilView(GroundBlock groundBlock)
        {
            var plowedSoilView = Instantiate(plowedSoilPrefab, transform);
            plowedSoilView.transform.position = groundBlock.Pos;
        }
    }
}