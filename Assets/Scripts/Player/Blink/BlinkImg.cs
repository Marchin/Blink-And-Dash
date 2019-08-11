using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkImg : MonoBehaviour {
    private bool isColliding = false;
    private SpriteRenderer spriteRenderer;
    Collider2D blinkCollider;
    [SerializeField]
    LayerMask excludeCheckpoints;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        blinkCollider = GetComponent<Collider2D>();
    }
    
    void Update() {

    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (blinkCollider.IsTouchingLayers(excludeCheckpoints)) {
            SetColliding(true);
        }
    }

    private void OnTriggerExit2D() {
        SetColliding(false);
    }

    public void SetColliding (bool state) {
        isColliding = state;
        if (state) {
            spriteRenderer.color = Color.red;
        } else {
            spriteRenderer.color = Color.yellow;
        }
    }

    public bool GetColliding() {
        return isColliding;
    }
}
