using UnityEngine;

namespace View
{
    public class CharacterView : MonoBehaviour
    {
        private int AttackHash = Animator.StringToHash("Attack");

        [SerializeField] private Animator _animator;

        public void AttackAnimation()
        {
            _animator.SetTrigger(AttackHash);
        }
    }
}
