using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator playerAnim;

    void Awake()
    {
        playerAnim = GetComponent<Animator>();
    }

    public void IdleAnimations()
    {
        playerAnim.Play("Idle");
    }

    public void PullingAnimations()
    {
        playerAnim.Play("RopeWrap");
    }

    public void LaughAnimations()
    {
        playerAnim.Play("Cheer");
    }
}
