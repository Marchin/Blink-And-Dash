using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Portal's global Cooldown
public  class ThePortalController : MonoBehaviour {
    const float timerCooldown = 1f;
    static float timerCurrent = -1f;
    static bool portalsEnabled = true;

    void Start() {
    }
    
    void  Update() {
        CounterEnable();
    }

    void CounterEnable() {
        if (timerCurrent > 0f) {
            timerCurrent -= Time.deltaTime;
        }
        else if (timerCurrent <= 0f) {
            timerCurrent = -1f;
            portalsEnabled = true;
        }
    }

    void ActivateTimer() {
        timerCurrent = timerCooldown;
    }

    public void DisablePortals() {
        portalsEnabled = false;
        ActivateTimer();
    }

    public bool ArePortalsEnabled() {
        return portalsEnabled;
    }
}
