using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheCollectableController : MonoBehaviour {
    int levelCollectables = 0;
    int totalLevelCollectables = 0;
    CollectableUIText collectableUI;

    void Start () {
        collectableUI = GetComponentInChildren<CollectableUIText>();
        collectableUI.Deactivate();
    }

	void Update (){
		
	}

    public void AddCollectable() {
        if (!collectableUI.isActiveAndEnabled) {
            collectableUI.Activate();
        }
        levelCollectables++;
        totalLevelCollectables++;
    }

    public void RemoveCollectable() {
        levelCollectables--;
    }

    public void ResetCollectables() {
        totalLevelCollectables = 0;
        collectableUI.Deactivate();
    }

    public bool AreCollectablesRemaining() {
        return (levelCollectables > 0);
    }

    public int GetCurrentCollectables() {
        return levelCollectables;
    }

    public int GetTotalCollectables() {
        return totalLevelCollectables;
    }
}
