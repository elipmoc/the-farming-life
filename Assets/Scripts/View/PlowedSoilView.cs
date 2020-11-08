using UnityEngine;

namespace Assets.Scripts.View
{
    public class PlowedSoilView : MonoBehaviour
    {
        [SerializeField]
        GameObject growth1 = null;
        [SerializeField]
        GameObject growth2 = null;
        [SerializeField]
        GameObject growth3 = null;

        public void SetGrowth1()
        {
            ClearGrowth();
            growth1.SetActive(true);
        }

        public void SetGrowth2()
        {
            ClearGrowth();
            growth2.SetActive(true);
        }

        public void SetGrowth3()
        {
            ClearGrowth();
            growth3.SetActive(true);
        }

        public void ClearGrowth()
        {
            growth1.SetActive(false);
            growth2.SetActive(false);
            growth3.SetActive(false);
        }
    }
}
