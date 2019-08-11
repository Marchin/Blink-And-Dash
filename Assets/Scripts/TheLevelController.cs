using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheLevelController : MonoBehaviour {
    MusicManager musicManager;

    void Start() {
        musicManager = GetComponent<MusicManager>();
    }

    void Update() { }

    public void NextLevel() {
        int newSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (newSceneIndex < SceneManager.sceneCountInBuildSettings) {
            SceneManager.LoadScene(newSceneIndex, LoadSceneMode.Single);
        } else {
            EndGame();
        }
    }

    void EndGame() {
        musicManager.VictorySound();
        StopGame();
    }

    public void StopGame() {
        Application.Quit();
    }

}