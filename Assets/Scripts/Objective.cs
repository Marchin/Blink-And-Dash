using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Objective : MonoBehaviour {
    const float LIMIT = 0.25f;
    private Vector3 movement;
    private float stack = LIMIT / 2;
    private float counter = 0.005f;
    Color semiTransparentColor = new Color(0.25f, 1f, 0.25f, 0.1f);
    Color opaqueColor = new Color(0.25f, 1f, 0.25f, 1f);
    SpriteRenderer spriteRenderer;
    TheLevelController theLevelController;
    TheCollectableController theCollectableController; 

    void Start() {
        movement = new Vector3(0f, counter, 0);
        spriteRenderer = GetComponent<SpriteRenderer>();
        theLevelController = GameObject.Find("_SCRIPTS_")
            .GetComponent<TheLevelController>();
        theCollectableController = GameObject.Find("_SCRIPTS_")
            .GetComponent<TheCollectableController>();

        spriteRenderer.color = semiTransparentColor;
    }

    void Update() {
        if (!theCollectableController.AreCollectablesRemaining()) {
            spriteRenderer.color = opaqueColor;
        }
    }

    void FixedUpdate() {
        MoveObjective();
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (!theCollectableController.AreCollectablesRemaining()) {
            theCollectableController.ResetCollectables();
            theLevelController.NextLevel();
        }
    }

    void MoveObjective() {
        transform.position += movement;
        stack += counter;
        if (Mathf.Abs(stack) > LIMIT) {
            ChangeDirection();
        }
    }

    void ChangeDirection() {
        stack = 0;
        movement = -movement;
    }

}
