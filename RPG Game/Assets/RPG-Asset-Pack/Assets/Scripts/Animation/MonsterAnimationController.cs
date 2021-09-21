using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimationController : MonoBehaviour
{
    
    private Animator MonsterAnimator;

    private const string IDLE_ANIMATION_BOOL = "idle";
    private const string WALK_ANIMATION_BOOL = "walk";
    private const string ATTACKRUN_ANIMATION_BOOL = "attack_run";
    private const string ATTACK_ANIMATION_BOOL = "attack";
    private const string DAMAGE_ANIMATION_BOOL = "damage";
    private const string SKILL_ANIMATION_BOOL = "skill";
    private const string DEAD_ANIMATION_BOOL = "dead";


    public void AnimateIdle()
    {
        Animate(IDLE_ANIMATION_BOOL);
    }

    public void AnimateWalk()
    {
        Animate(WALK_ANIMATION_BOOL);
    }

    public void AnimateAttackRun()
    {
        Animate(ATTACKRUN_ANIMATION_BOOL);
    }

    public void AnimateAttack()
    {
        Animate(ATTACK_ANIMATION_BOOL);
    }

    public void AnimateDamage()
    {
        Animate(DAMAGE_ANIMATION_BOOL);
    }

    public void AnimateSkill()
    {
        Animate(SKILL_ANIMATION_BOOL);
    }

    public void AnimateDead()
    {
        Animate(DEAD_ANIMATION_BOOL);
    }


    private void Start()
    {
        MonsterAnimator = GetComponent<Animator>();
    }

    private void Animate(string boolName)
    {
        DisableOtherAnimations(MonsterAnimator, boolName);

        MonsterAnimator.SetBool(boolName, true);
    }

    private void DisableOtherAnimations(Animator MonsterAnimator, string animation)
    {
        foreach (AnimatorControllerParameter parameter in MonsterAnimator.parameters)
        {
            if (parameter.name != animation)
            {
                MonsterAnimator.SetBool(parameter.name, false);
            }
        }
    }
}
