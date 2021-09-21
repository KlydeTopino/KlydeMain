using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimationController : MonoBehaviour
{
    private Animator NPCAnimator;

    private const string IDLE_ANIMATION_BOOL = "idle";
    private const string TALK_ANIMATION_BOOL = "talk";

    public void AnimateIdle()
    {
        Animate(IDLE_ANIMATION_BOOL);
    }

    public void AnimateTalk()
    {
        Animate(TALK_ANIMATION_BOOL);
    }

    private void Start()
    {
        NPCAnimator = GetComponent<Animator>();
    }

    private void Animate(string boolName)
    {
        DisableOtherAnimations(NPCAnimator, boolName);

        NPCAnimator.SetBool(boolName, true);
    }

    private void DisableOtherAnimations(Animator NPCAnimator, string animation)
    {
        foreach (AnimatorControllerParameter parameter in NPCAnimator.parameters)
        {
            if (parameter.name != animation)
            {
                NPCAnimator.SetBool(parameter.name, false);
            }
        }
    }

}
