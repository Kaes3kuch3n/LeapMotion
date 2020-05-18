using System.Collections;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(Animation))]
    public class MenuAnimator : MonoBehaviour
    {
        [SerializeField] private GameObject menuPanel;
        [SerializeField] private AnimationClip openAnimation;
        [SerializeField] private AnimationClip closeAnimation;

        private Animation _animation;
        private bool _isOpen = false;

        private void Awake()
        {
            _animation = GetComponent<Animation>();
            menuPanel.SetActive(_isOpen);
        }

        public void Open()
        {
            if (_isOpen)
                return;
            
            menuPanel.SetActive(true);
            _animation.clip = openAnimation;
            _animation.Play();
            _isOpen = true;
        }

        public void Close()
        {
            if (!_isOpen)
                return;
            
            _animation.clip = closeAnimation;
            _animation.Play();
            StartCoroutine(DeactivateAfterAnimation());

            IEnumerator DeactivateAfterAnimation()
            {
                yield return new WaitForSeconds(0.5f);
                menuPanel.SetActive(false);
            }

            _isOpen = false;
        }
    }
}