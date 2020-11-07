using UnityEngine;
using UniRx;
using UniRx.Triggers;


namespace Assets.Scripts.View
{
    public class ToolSelectorView : MonoBehaviour
    {
        [SerializeField]
        ToolView[] tools = null;

        int currentSelectedToolIndex = 0;

        void Start()
        {
            SetCurrentSelectedTool(0);
            this.UpdateAsObservable().Subscribe(_ => UpdateSelectedTool());
        }

        void SetCurrentSelectedTool(int selectedToolIndex)
        {
            currentSelectedToolIndex = Mathf.Clamp(selectedToolIndex, 0, tools.Length - 1);
            foreach (var tool in tools)
                tool.SetIsSelectd(false);
            tools[currentSelectedToolIndex].SetIsSelectd(true);
        }

        private void UpdateSelectedTool()
        {
            if (Input.mouseScrollDelta.y > 0)
                SetCurrentSelectedTool(currentSelectedToolIndex - 1);
            if (Input.mouseScrollDelta.y < 0)
                SetCurrentSelectedTool(currentSelectedToolIndex + 1);
        }
    }
}