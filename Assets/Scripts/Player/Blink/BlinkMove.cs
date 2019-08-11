using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkMove : MonoBehaviour {
    bool blinking = false;
    const float blinkDuration = 3f;
    float blinkDurationTimer = blinkDuration;
    const float blinkCooldown = 5f;
    float blinkCooldownCurrent = 0f;
    Player playerBlinking;
    GameObject imgInst;
    PlayerMovement playerMovement;
    [SerializeField]
    GameObject blinkImg;
    Hotkeys hotkeys;

    private void Start() {
        playerBlinking = GetComponent<Player>();
        playerMovement = GetComponent<PlayerMovement>();
        hotkeys = GameObject.Find("_SCRIPTS_").
            GetComponent<Hotkeys>();
    }
    
    public void BlinkController() {
        if (hotkeys.IsBlinkUnpress() || BlinkTimeWentOut()) {
            StopBlink();
        } else if (hotkeys.IsBlinkPress() && !IsBlinkOnCooldown()) {
            StartBlink();
        } else if (IsBlinking()) {
            BlinkMov();
        }
        if (IsBlinkOnCooldown()) {
            blinkCooldownCurrent -= Time.deltaTime;
            if (!IsBlinkOnCooldown()) {
                playerBlinking.SetColor(Color.white);
            }
        }
    }

    public void StartBlink() {
        Vector3 iluOnFront = new Vector3(2 * (playerBlinking.IsFacingRight() ? 1 : -1), 0, 0);
        Vector3 iluPos = playerBlinking.GetPosition() + iluOnFront;
        blinking = true;
        playerMovement.FreezePlayer(true);
        imgInst = Instantiate(blinkImg, iluPos, Quaternion.identity);
        imgInst.transform.parent = playerBlinking.transform;
        if (!playerBlinking.IsFacingRight()) {
            Vector3 theScale = imgInst.transform.localScale;
            theScale.x *= -1;
            imgInst.transform.localScale = theScale;
        }
    }

    public void BlinkMov() {
        Vector3 movX = Vector3.right * 2;
        Vector3 movY = Vector3.up * 2;

        if (hotkeys.IsUpPress()) {
            imgInst.transform.position = playerBlinking.GetPosition() + movY;
        } else if (hotkeys.IsDownPress()) {
            imgInst.transform.position = playerBlinking.GetPosition() - movY;
        } else if (hotkeys.IsRightPress()) {
            imgInst.transform.position = playerBlinking.GetPosition() + movX;
        } else if (hotkeys.IsLeftPress()) {
            imgInst.transform.position = playerBlinking.GetPosition() - movX;
        }
        blinkDurationTimer-= Time.deltaTime;
    }

    public void StopBlink() {
        if (IsBlinking()) {
            BlinkImg aux = imgInst.GetComponent<BlinkImg>();
            blinking = false;
            playerMovement.FreezePlayer(false);
            if (!aux.GetColliding()) {
                playerBlinking.SetPosition(imgInst.transform.position);
                blinkCooldownCurrent = blinkCooldown;
                playerBlinking.SetColor(Color.gray);
            }
            Destroy(imgInst);
            blinkDurationTimer = blinkDuration;
        }
    }

    public bool IsBlinking() {
        return blinking;
    }

    bool IsBlinkOnCooldown() {
        return (blinkCooldownCurrent > 0f);
    }

    bool BlinkTimeWentOut() {
        return blinkDurationTimer <= 0f;
    }
}
