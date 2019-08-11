using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour {
    [SerializeField]
    AudioSource walkAudio;
    [SerializeField]
    AudioSource jumpAudio;
    PlayerMovement playerMovement;
    Hotkeys hotkeys;

    void Start (){
        playerMovement = GetComponent<PlayerMovement>();
        hotkeys = GameObject.Find("_SCRIPTS_").
            GetComponent<Hotkeys>();
    }

	void Update (){
        if ((hotkeys.IsLeftPress() != hotkeys.IsRightPress()) && walkAudio.enabled) {
            walkAudio.Play();
        }
        if ((!hotkeys.IsLeftPressed() && !hotkeys.IsRightPressed()) || !playerMovement.IsGrounded()) {
            walkAudio.Stop();
        }
        if (playerMovement.JustLanded() && (playerMovement.GetVelocityX() != 0f) && walkAudio.enabled) {
            walkAudio.Play();
        }
    }

    public void PlayJumpAudio() {
        jumpAudio.Play();
    }

    public void SetWalkAudio (bool state) {
        walkAudio.enabled = state;
    }
}
