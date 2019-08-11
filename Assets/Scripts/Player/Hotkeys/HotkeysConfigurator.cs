using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotkeysConfigurator : MonoBehaviour {
    private class Axys {
        string _axys;
        bool _positive;
        const float joyDeadzone = 0.5f;

        public Axys(string axys, bool positive) {
            _axys = axys;
            _positive = positive;
        }

        public bool GetAxyMov() {
            bool active = IsActive(_positive);
            return active;
        }

        bool IsActive(bool positive) {
            if (positive) {
                return (Input.GetAxis(_axys)> joyDeadzone);
            } else {
                return (Input.GetAxis(_axys)< (joyDeadzone * -1));
            }
        }
    }

    private class HotKey {
        KeyCode[] _key;
        Axys[] _axys;
        bool previousAxys = false;

        public HotKey(KeyCode[] key = null, Axys[] axys = null) {
            _key = key;
            _axys = axys;
        }

        private bool CheckHotKey(int HotkeyVariant, string status) {
            bool state = false;
            if (IsKey(HotkeyVariant)) {
                switch (status.ToLower()) {
                    case "up":
                        state = Input.GetKeyUp(_key[HotkeyVariant]);
                        break;
                    case "down":
                        state = Input.GetKeyDown(_key[HotkeyVariant]);
                        break;
                    case "hold":
                        state = Input.GetKey(_key[HotkeyVariant]);
                        break;
                }
            } else if (IsAxys(HotkeyVariant)) {
                int AxysVariant = HotkeyVariant - _key.Length;
                bool currentAxys = _axys[AxysVariant].GetAxyMov();
                switch (status.ToLower()) {
                    case "up":
                        state = (!currentAxys && previousAxys);
                        break;
                    case "down":
                        state = (currentAxys && !previousAxys);
                        break;
                    case "hold":
                        state = (currentAxys && previousAxys);
                        break;
                }
                previousAxys = currentAxys;
            }
            return state;
        }

        private int GetLenght() {
            int a = 0;
            int b = 0;
            if (_key != null) {
                a = _key.Length;
            }
            if (_axys != null) {
                b = _axys.Length;
            }
            return (a + b);
        }

        bool IsKey(int HotkeyVariant) {
            return (0 <= HotkeyVariant)&& (HotkeyVariant < _key.Length);
        }

        bool IsAxys(int HotkeyVariant) {
            return (_key.Length <= HotkeyVariant)&& (HotkeyVariant < GetLenght());
        }

        public bool GetHotKey(string status) {
            for (int HotkeyVariant = 0; HotkeyVariant < GetLenght(); HotkeyVariant++) {
                if (CheckHotKey(HotkeyVariant, status))return true;
            }
            return false;
        }
    }

    Dictionary<string, HotKey> hotkeys = new Dictionary<string, HotKey>();

    void Start() {
        DontDestroyOnLoad(gameObject);
        hotkeys.Add("right",
            new HotKey(new KeyCode[] { KeyCode.RightArrow, KeyCode.D },
                new Axys[] { new Axys("Horizontal", true)}));
        hotkeys.Add("left",
            new HotKey(new KeyCode[] { KeyCode.LeftArrow, KeyCode.A },
                new Axys[] { new Axys("Horizontal", false)}));
        hotkeys.Add("up",
            new HotKey(new KeyCode[] { KeyCode.UpArrow, KeyCode.W },
                new Axys[] { new Axys("Vertical", true)}));
        hotkeys.Add("down",
            new HotKey(new KeyCode[] { KeyCode.DownArrow, KeyCode.S },
                new Axys[] { new Axys("Vertical", false)}));
        hotkeys.Add("jump",
            new HotKey(new KeyCode[] { KeyCode.Space, KeyCode.Joystick1Button0 }));
        hotkeys.Add("blink",
            new HotKey(new KeyCode[] { KeyCode.B, KeyCode.Joystick1Button1 }));
        hotkeys.Add("enter",
            new HotKey(new KeyCode[] { KeyCode.Insert, KeyCode.Space, KeyCode.Joystick1Button0 }));
    }

    public bool GetHotkeys(string name, string status) {
        return hotkeys[name.ToLower()].GetHotKey(status);
    }
}