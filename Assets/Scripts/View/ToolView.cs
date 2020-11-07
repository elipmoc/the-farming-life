using UnityEngine;

namespace Assets.Scripts.View
{
    public class ToolView : MonoBehaviour
    {
        [SerializeField]
        Animator animator = null;

        public void SetIsSelectd(bool flag)
        {
            animator.SetBool("is_selected", flag);
        }
    }
}
