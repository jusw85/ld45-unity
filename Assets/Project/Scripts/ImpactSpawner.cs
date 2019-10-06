using UnityEngine;

public class ImpactSpawner : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SpawnSmall()
    {
        animator.ResetTrigger("LargeImpact");
        animator.SetTrigger("SmallImpact");
    }

    public void SpawnLarge()
    {
        animator.ResetTrigger("SmallImpact");
        animator.SetTrigger("LargeImpact");
    }

}