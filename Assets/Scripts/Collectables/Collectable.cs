using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {
    bool waitForRemove = false;
    TheCollectableController theCollectableController;

    void Start () {
        theCollectableController = GameObject.Find("_SCRIPTS_")
            .GetComponent<TheCollectableController>();
        theCollectableController.AddCollectable();
    }

	void LateUpdate (){
		if (waitForRemove) {
            theCollectableController.RemoveCollectable();
            DestroyObject(gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            waitForRemove = true;
        }
    }
}
