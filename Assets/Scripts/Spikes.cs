using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {
    GameObject playerObject;
    Player player;
    const float timerCooldown = 1f;
    float timer = -1f;

	void Start (){
		playerObject = GameObject.Find("Player");
        player = playerObject.GetComponent<Player>();
	}

	void Update () {
        //Count();
    }

    private void Count() {
        if (IsTimerStillCounting()) {
            timer -= Time.deltaTime;
        } else {
            DisableTimer();
        }
    }
    
    bool IsTimerStillCounting() {
        return timer > 0f ? true : false;
    }

    void DisableTimer() {
        timer = -1f;
    }

    private void OnTriggerEnter2D(Collider2D other) {
       // if ((IsCollisionFromPlayer(other)) && !IsTimerStillCounting())
        if (IsCollisionFromPlayer(other)) {
                player.TakeDmg();
            //EnableTimer();
        }
    }

    bool IsCollisionFromPlayer(Collider2D other) {
        return other.gameObject == playerObject;
    }

    void EnableTimer() {
        timer = timerCooldown;
    }
}
