using System;
using UnityEngine;

namespace View
{
    public class AttackButtonView : MonoBehaviour
    {
        public event Action AttackClicked;

        public void OnAttackClicked()
        {
            AttackClicked?.Invoke();
        }
    }
}
