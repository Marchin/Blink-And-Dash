using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringPlatform : MonoBehaviour {
    [SerializeField]
    [Range (0f, 5f)]
    float flickerPeriod;
    float flickerTimer;
    bool visible = true;

	void Start (){
        flickerTimer = flickerPeriod;
	}

	void Update (){
        flickerTimer -= Time.deltaTime;
        if (flickerTimer <= 0f) {
            Flick();
        }
	}

    void Flick() {
        GetComponent<SpriteRenderer>().enabled = visible;
        GetComponent<Collider2D>().enabled = visible;
        visible = !visible;
        flickerTimer = flickerPeriod;
    }
}
