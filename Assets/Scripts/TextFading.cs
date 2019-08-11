using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextFading : MonoBehaviour {
    TextMeshPro text;
    bool fading = false;
    Color textColor = Color.white;
    float fadeFactor = 0.5f;

	void Start (){
        text = GetComponent<TextMeshPro>();
	}

	void Update (){
		if (IsFading()) {
            Fade();
        }
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            fading = true;
        }
    }

    bool IsFading() {
        return fading;
    }

    void Fade() {
        textColor.a -= (Time.deltaTime * fadeFactor);
        text.color = textColor;
        if (textColor.a <= 0f) {
            DestroyObject(gameObject);
        }
    }
}
