using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
    Player player;

	void Start (){
        player = FindObjectOfType<Player>();	
	}
    
    private void OnTriggerEnter2D(Collider2D collision) {
        player.CPUpdate(transform.position);
    }
}
