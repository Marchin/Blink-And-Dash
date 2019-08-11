using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectableUIText : MonoBehaviour {
    TextMeshProUGUI collectableText;
    TheCollectableController theCollectableController;
    int levelCollectables = 0;
    int totalLevelCollectables = 0;
    int collectablesLeft = 0;

    void Start (){
        collectableText = GetComponent<TextMeshProUGUI>();
        theCollectableController = GameObject.Find("_SCRIPTS_")
            .GetComponent<TheCollectableController>();
	}

	void LateUpdate (){
        levelCollectables = theCollectableController.GetCurrentCollectables();
        totalLevelCollectables = theCollectableController.GetTotalCollectables();
        collectablesLeft = totalLevelCollectables - levelCollectables;
        collectableText.text = System.String.Format("{0}/{1}", collectablesLeft, totalLevelCollectables);
	}
    
    public void Activate() {
        gameObject.SetActive(true);
    }

    public void Deactivate() {
        gameObject.SetActive(false);
    }
}
