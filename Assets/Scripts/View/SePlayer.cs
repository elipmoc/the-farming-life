using UnityEngine;

namespace Assets.Scripts.View
{
    class SePlayer : MonoBehaviour
    {
        [SerializeField]
        AudioSource audioSource = null;

        [SerializeField]
        AudioClip tagayasu = null;

        [SerializeField]
        AudioClip tanemaku = null;

        public void PlayTagayasu()
        {
            audioSource.PlayOneShot(tagayasu);
        }

        public void PlayTanemaku()
        {
            audioSource.PlayOneShot(tanemaku);
        }
    }
}
