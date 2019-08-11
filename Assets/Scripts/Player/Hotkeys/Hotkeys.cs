using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotkeys : MonoBehaviour {
    HotkeysConfigurator hotkeysConfigurator;
    #region Hotkeys
    bool pressBlink;
    bool unpressBlink;
    bool pressLeft;
    bool unpressLeft;
    bool pressedLeft;
    bool pressRight;
    bool unpressRight;
    bool pressedRight;
    bool pressUp;
    bool pressDown;
    bool pressJump;
    bool unpressJump;
    bool pressEnter;
    #endregion

    void Start() {
        hotkeysConfigurator = GameObject.Find("_SCRIPTS_").
        GetComponent<HotkeysConfigurator>();
    }

    public void CheckKeys() {
        pressLeft = hotkeysConfigurator.GetHotkeys("Left", "down");
        pressedLeft = hotkeysConfigurator.GetHotkeys("Left", "hold");
        unpressLeft = hotkeysConfigurator.GetHotkeys("Left", "up");
        pressRight = hotkeysConfigurator.GetHotkeys("Right", "down");
        pressedRight = hotkeysConfigurator.GetHotkeys("Right", "hold");
        unpressRight = hotkeysConfigurator.GetHotkeys("Right", "up");
        pressUp = hotkeysConfigurator.GetHotkeys("Up", "down");
        pressDown = hotkeysConfigurator.GetHotkeys("Down", "down");
        pressJump = hotkeysConfigurator.GetHotkeys("Jump", "down");
        pressBlink = hotkeysConfigurator.GetHotkeys("Blink", "down");
        unpressBlink = hotkeysConfigurator.GetHotkeys("Blink", "up");
        pressEnter = hotkeysConfigurator.GetHotkeys("Enter", "down");
    }
    #region Left
    public bool IsLeftPress() {
        return pressLeft;
    }

    public bool IsLeftPressed() {
        return pressedLeft;
    }

    public bool IsLeftUnpress() {
        return unpressLeft;
    }
    #endregion
    #region Right
    public bool IsRightPress() {
        return pressRight;
    }

    public bool IsRightPressed() {
        return pressedRight;
    }

    public bool IsRightUnpress() {
        return unpressRight;
    }
    #endregion
    #region Up
    public bool IsUpPress() {
        return pressUp;
    }
    #endregion
    #region Down
    public bool IsDownPress() {
        return pressDown;
    }
    #endregion
    #region Jump
    public bool IsJumpPress() {
        return pressJump;
    }
    #endregion
    #region Blink
    public bool IsBlinkPress() {
        return pressBlink;
    }

    public bool IsBlinkUnpress() {
        return unpressBlink;
    }
    #endregion

    public bool IsEnterPress() {
        return pressEnter;
    }
}