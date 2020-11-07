using UnityEngine;

namespace Assets.Scripts.View
{
    class SePlayer : MonoBehaviour
    {
        [SerializeField]
        AudioSource audioSource = null;

        [SerializeField]
        AudioClip tagayasu = null;

        public void PlayTagayasu()
        {
            audioSource.PlayOneShot(tagayasu);
        }
    }
}
