using UnityEngine;

public class TheUIController : MonoBehaviour {
    TheLevelController theLevelController;
    GameObject mainMenu;
    Hotkeys hotkeys;
    void Start() {
        theLevelController = GetComponent<TheLevelController>();
        mainMenu = GameObject.Find("Main Menu");
    }

    void Update() {
        StartPlayPulling();
    }

    void StartPlayPulling() {
        if (CheckEnter() && mainMenu.activeInHierarchy) {
            HideMainMenu();
            theLevelController.NextLevel();
        }
    }

    public void HideMainMenu() {
        mainMenu.SetActive(false);
    }

    bool CheckEnter() {
        return (
            Input.GetKey(KeyCode.Return) ||
            Input.GetKey(KeyCode.Space) ||
            Input.GetKey(KeyCode.Joystick1Button0)
        );
    }
}