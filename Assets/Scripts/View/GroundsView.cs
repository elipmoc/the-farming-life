using UnityEngine;

namespace Assets.Scripts.View
{
    public class GroundsView : MonoBehaviour
    {
        public void PutPlowedSoilView(PlowedSoilView plowedSoilView)
        {
            plowedSoilView.transform.parent = transform;
        }
    }
}