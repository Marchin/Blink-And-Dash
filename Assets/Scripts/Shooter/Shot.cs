using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {
    Player player;
    float lifeTime = 3f;

    void Start() {
        player = GameObject.Find("Player").
            GetComponent<Player>();
    }

    void Update() {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0f) {
            DestroyObject(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject == player.gameObject) {
            player.TakeDmg();
        }
        DestroyObject(gameObject);
    }
}