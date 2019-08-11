using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Portal : MonoBehaviour {
    public GameObject portalObjective;
    public AudioSource portalAudio;
    GameObject playerObject;
    Player player;
    GameObject cameraObject;
    CameraController cameraController;
    ThePortalController thePortalController;
    Vector3 heightCorrector = new Vector3(0f, 0.5f, 0f);

    void Start() {
        cameraObject = GameObject.Find("Main Camera");
        cameraController = cameraObject.GetComponent<CameraController>();
        playerObject = GameObject.Find("Player");
        player = playerObject.GetComponent<Player>();
        thePortalController = GameObject.Find("_SCRIPTS_")
            .GetComponent<ThePortalController>();
    }
    
    void Update() {}

    void OnTriggerEnter2D(Collider2D other) {
        if (IsTriggeredByPlayer(other) && thePortalController.ArePortalsEnabled()){
            thePortalController.DisablePortals();
            player.SetPosition(portalObjective.transform.position + heightCorrector);
            cameraController.AdjustCamera();
            portalAudio.Play();
        }
    }

    bool IsTriggeredByPlayer (Collider2D other) {
        return other.gameObject == playerObject;
    }
}
