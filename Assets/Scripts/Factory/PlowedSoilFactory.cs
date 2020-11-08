using Assets.Scripts.Model;
using Assets.Scripts.View;
using UnityEngine;
using UniRx;

namespace Assets.Scripts.Factory
{
    class PlowedSoilFactory : MonoBehaviour
    {
        [SerializeField]
        PlowedSoilView plowedSoilPrefab = null;

        public PlowedSoilView CreatePlowedSoilView(GroundBlock groundBlock)
        {
            var plowedSoilView = Instantiate(plowedSoilPrefab);
            plowedSoilView.transform.position = groundBlock.Pos;
            groundBlock.State.Subscribe(state =>
            {
                switch (state)
                {
                    case GroundBlockState.Growth1:
                        plowedSoilView.SetGrowth1();
                        break;
                    case GroundBlockState.Growth2:
                        plowedSoilView.SetGrowth2();
                        break;
                    case GroundBlockState.Growth3:
                        plowedSoilView.SetGrowth3();
                        break;
                    case GroundBlockState.None:
                        plowedSoilView.ClearGrowth();
                        break;
                }
            });
            return plowedSoilView;
        }
    }
}
