using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.View
{
    public class ClockView : MonoBehaviour
    {
        [SerializeField]
        Text text = null;

        public void SetTime(int hours, int minutes)
        {
            text.text = hours.ToString("D2") + ":" + minutes.ToString("D2");
        }
    }
}
