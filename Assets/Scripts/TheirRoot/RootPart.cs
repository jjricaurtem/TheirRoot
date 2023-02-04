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
        public void Start()
        {
            if (myRootSpriteRenderer == null) TryGetComponent(out myRootSpriteRenderer);
            if (animator == null) TryGetComponent(out animator);
            animator.SetTrigger("Idle");
        }
        public void RootChangeAnimation()
        {
            animator.SetTrigger("ChangeRoot");
        }
        
       public void RootDropSound()
       {
            MainMusicEventChannel.rootChangeMuisic.Invoke(rootChangeSound);
       }
    }
}
