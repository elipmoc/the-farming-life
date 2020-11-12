using Assets.Scripts.Factory;
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

        [SerializeField]
        ToolSelectorView toolSelectorView = null;

        [SerializeField]
        PlowedSoilFactory plowedSoilFactory = null;

        Ground ground = new Ground();

        void Awake()
        {
            ground.OnCreatedGround.Subscribe(groundBlock =>
            {
                groundsView.PutPlowedSoilView(plowedSoilFactory.CreatePlowedSoilView(groundBlock));
                sePlayer.PlayTagayasu();
            });

            ground.OnSeeded.Subscribe(_ => sePlayer.PlayTanemaku());

            playerCommandInput.OnLeftClicked
                .Where(_ => toolSelectorView.SelectedToolKind == ToolKind.Kuwa)
                .Subscribe(clickInfo => ground.Plow(clickInfo.Pos));

            playerCommandInput.OnLeftClicked
            .Where(_ => toolSelectorView.SelectedToolKind == ToolKind.TaneFukuro)
            .Subscribe(clickInfo => ground.Seed(clickInfo.Pos));
        }
    }
}
