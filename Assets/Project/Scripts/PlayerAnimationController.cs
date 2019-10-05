using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    private Action attackExitCallback;

    private static Dictionary<string, int> paramIdMap;

    private static readonly string[] paramIds =
        {"AbsHSpeed", "VSpeed", "IsGrounded", "WalkSpeedMultiplier", "AttackTrigger"};

    private void Awake()
    {
        animator = GetComponent<Animator>();
        if (paramIdMap == null)
        {
            paramIdMap = new Dictionary<string, int>();
            foreach (var paramId in paramIds)
            {
                paramIdMap.Add(paramId, Animator.StringToHash(paramId));
            }
        }
    }

    public void SetVelocity(Vector2 velocity)
    {
        animator.SetFloat(paramIdMap["AbsHSpeed"], Mathf.Abs(velocity.x));
        animator.SetFloat(paramIdMap["VSpeed"], velocity.y);
    }

    public void SetIsGrounded(bool val)
    {
        animator.SetBool(paramIdMap["IsGrounded"], val);
    }

    public void SetMoveSpeed(float moveSpeed)
    {
        animator.SetFloat(paramIdMap["WalkSpeedMultiplier"], moveSpeed * 0.25f);
    }

    public void AnimateAttack(Action attackExitCallback)
    {
        animator.SetTrigger(paramIdMap["AttackTrigger"]);
        this.attackExitCallback = attackExitCallback;
    }

    public void DoAttackExitCallback()
    {
        attackExitCallback?.Invoke();
    }

    private void DebugClipLength()
    {
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        foreach (var clip in clips)
        {
            Debug.Log(clip.name + " " + clip.length);
        }
    }
}