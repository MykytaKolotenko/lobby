using UnityEngine;

namespace LobbyState.MenuButton
{
    public class MenuButtonAnimator : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private string initAnimation = "MenuButtonClosed";

        private int _activeHash = Animator.StringToHash("Active");
        private int _hideHash = Animator.StringToHash("Hide");

        public void Init()
        {
            animator.Play(initAnimation, 0, 1f);
        }

        public void SetActive()
        {
            animator.SetTrigger(_activeHash);
        }

        public void SetHide()
        {
            animator.SetTrigger(_hideHash);
        }
    }
}
