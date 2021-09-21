using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{

    private Animator PlayerAnimator;

    private const string IDLE_ANIMATION_BOOL = "idle";
    private const string RUN_ANIMATION_BOOL = "run";
    private const string ATTACKRUN_ANIMATION_BOOL = "attack_run";
    private const string ATTACK_ANIMATION_BOOL = "attack";
    private const string ATTACKSTANDBY_ANIMATION_BOOL = "attack_standby";
    private const string COMBO_ANIMATION_BOOL = "combo";
    private const string DRAWBLADE_ANIMATION_BOOL = "draw_blade";
    private const string PUTBLADE_ANIMATION_BOOL = "put_blade";
    private const string DAMAGE_ANIMATION_BOOL = "damage";
    private const string SKILL_ANIMATION_BOOL = "skill";
    private const string DEAD_ANIMATION_BOOL = "dead";



    public void AnimateIdle()
    {
        Animate(IDLE_ANIMATION_BOOL);
    }

    public void AnimateRun()
    {
        Animate(RUN_ANIMATION_BOOL);
    }

    public void AnimateAttackRun()
    {
        Animate(ATTACKRUN_ANIMATION_BOOL);
    }

    public void AnimateAttack()
    {
        Animate(ATTACK_ANIMATION_BOOL);
    }

    public void AnimateAttackStandby()
    {
        Animate(ATTACKSTANDBY_ANIMATION_BOOL);
    }

    public void AnimateCombo()
    {
        Animate(COMBO_ANIMATION_BOOL);
    }

    public void AnimateDrawBlade()
    {
        Animate(DRAWBLADE_ANIMATION_BOOL);
    }

    public void AnimatePutBlade()
    {
        Animate(PUTBLADE_ANIMATION_BOOL);
    }

    public void AnimateDamage()
    {
        Animate(DAMAGE_ANIMATION_BOOL);
    }

    public void AnimateSkill()
    {
        Animate(SKILL_ANIMATION_BOOL);
    }

    public void AnimateDeath()
    {
        Animate(DEAD_ANIMATION_BOOL);
    }





    // Start is called before the first frame update
    private void Start()
    {
        PlayerAnimator = GetComponent<Animator>();
    }

    private void Animate(string boolname)
    {
        DisableOtherAnimations(PlayerAnimator, boolname);

        PlayerAnimator.SetBool(boolname, true);
    }


    private void DisableOtherAnimations(Animator PlayerAnimator, string animation)
    {
        foreach(AnimatorControllerParameter parameter in PlayerAnimator.parameters)
        {
            if (parameter.name != animation)
            {
                PlayerAnimator.SetBool(parameter.name, false);
            }
        }
    }

  
}
