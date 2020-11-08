using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Assets.Scripts.Model;

namespace Assets.Scripts.View
{
    public class ToolSelectorView : MonoBehaviour
    {
        [SerializeField]
        ToolView[] tools = null;

        int selectedToolIndex = 0;

        public ToolKind SelectedToolKind => (ToolKind)selectedToolIndex;

        void Start()
        {
            SetSelectedTool(0);
            this.UpdateAsObservable().Subscribe(_ => UpdateSelectedTool());
        }

        void SetSelectedTool(int newSelectedToolIndex)
        {
            selectedToolIndex = Mathf.Clamp(newSelectedToolIndex, 0, tools.Length - 1);
            foreach (var tool in tools)
                tool.SetIsSelectd(false);
            tools[selectedToolIndex].SetIsSelectd(true);
        }

        private void UpdateSelectedTool()
        {
            if (Input.mouseScrollDelta.y > 0)
                SetSelectedTool(selectedToolIndex - 1);
            if (Input.mouseScrollDelta.y < 0)
                SetSelectedTool(selectedToolIndex + 1);
        }
    }
}