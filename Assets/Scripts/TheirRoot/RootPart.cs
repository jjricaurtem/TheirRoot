using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheirRoot
{
    public class RootPart : MonoBehaviour, IItem
    {
        public MainMusicEventChannel MainMusicEventChannel;
        public RootPartJoins RootPartJoin;
        public Renderer myRootRender;
        public SpriteRenderer myRootSpriteRenderer;
        public Animator animator;
        public AudioClip rootChangeSound;
        private AudioSource _audioSource;
        public void Start()
        {
            if (myRootSpriteRenderer == null) TryGetComponent(out myRootSpriteRenderer);
            if (_audioSource == null) TryGetComponent(out _audioSource);
            if (animator == null) TryGetComponent(out animator);
            animator.SetTrigger("Idle");
        }
        public void RootChangeAnimation()
        {
            animator.SetTrigger("ChangeRoot");
        }
        
       public void RootDropSound()
       {
            _audioSource.Play();
        }
    }
}
