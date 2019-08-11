using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {
    Animator animator;
    PlayerMovement playerMovement;

    void Start () {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

	void Update () {
        if ((playerMovement.GetVelocityX() != 0f) && (playerMovement.IsGrounded())) {
            animator.SetTrigger("Walk");
        }
        if (playerMovement.GetVelocityX() == 0f) {
            animator.SetTrigger("Idle");
        }
        animator.SetBool("OnGround", playerMovement.IsGrounded());
    }

    public void TriggerJumpAnimation() {
        animator.SetTrigger("Jump");
    }

    public void SetBlinkAnimation(bool state) {
        animator.SetBool("Blink", state);
    }
}
