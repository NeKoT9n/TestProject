using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Features.Rewards.UI
{
    public class ButtonAnimation : MonoBehaviour
    {

        [SerializeField] private Animator _animator;
        private const string ANIMATION = "Anim";
        public bool ShoudPlay { get; set; }


        private void OnEnable()
        {
            if(ShoudPlay == true)
            Play();
        }

        private void OnDisable()
        {
            Stop();
        }

        public void Play()
        {
            _animator.SetBool(ANIMATION, true);
        }

        public void Stop()
        {
            _animator.SetBool(ANIMATION, false);
        }
    }
}