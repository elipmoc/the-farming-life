using Assets.Scripts.Model;
using Assets.Scripts.View;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.Presenter
{
    class WorldPresenter : MonoBehaviour
    {
        [SerializeField]
        GroundsView groundsView = null;

        [SerializeField]
        PlayerCommandInput playerCommandInput = null;

        [SerializeField]
        SePlayer sePlayer = null;

        Ground ground = new Ground();

        void Awake()
        {
            ground.OnCreatedGround.Subscribe(plowedSoilInfo =>
            {
                groundsView.PutPlowedSoilView(plowedSoilInfo);
                sePlayer.PlayTagayasu();
            });

            playerCommandInput.OnLeftClicked
                .Subscribe(clickInfo => ground.OnPlowed(clickInfo.Pos));
        }
    }
}
