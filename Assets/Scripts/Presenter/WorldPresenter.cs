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

            playerCommandInput.OnLeftClicked
                .Where(_ => toolSelectorView.SelectedToolKind == ToolKind.Kuwa)
                .Subscribe(clickInfo => ground.OnPlowed(clickInfo.Pos));

            playerCommandInput.OnLeftClicked
            .Where(_ => toolSelectorView.SelectedToolKind == ToolKind.TaneFukuro)
            .Subscribe(clickInfo => ground.OnSeeded(clickInfo.Pos));
        }
    }
}
