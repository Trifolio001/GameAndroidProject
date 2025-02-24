using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    public Animator animator;
    public List<AnimatorSetup> animatorSetup;

    public enum AnimationType
    {
        START,
        IDLE,
        RUN,
        DEAD,
        FLY,
        MAGNETIC
    }

    public void Play(AnimationType type, float currentSpeedFactor = 1)
    {
        foreach (var animation in animatorSetup)
        {
            if (animation.type == type)
            {
                animator.SetTrigger(animation.trigger);
                animator.speed = animation.speed * currentSpeedFactor;
                break;
            }
        }
    }

   

    [System.Serializable]
    public class AnimatorSetup
    {
        public AnimatorManager.AnimationType type; 
        public string trigger;
        public float speed = 1f;
    }
}
