using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjRadCont : MonoBehaviour {
    #region Variables
    private GameObject objective;
    private GameObject player;
    private RectTransform objectiveRadarPosition;
    private GameObject radar;
    private RectTransform radarPosition;
    const float radarRange = 3f;
    float objectiveRadarPositionX = 0f;
    float objectiveRadarPositionY = 0f;
    float distanceX;
    float distanceY;
    #endregion

    void Start() {
        player = GameObject.Find("Player");
        objective = GameObject.Find("Objective");
        radar = GameObject.Find("Radar");
        objectiveRadarPosition = GetComponent<RectTransform>();
        radarPosition = radar.GetComponent<RectTransform>();
    }

    void Update() {
        CalculateDistance();
        CalculateObjectiveRadarPosition();
        SetObjectiveRadarPosition();
    }

    void CalculateDistance() {
        distanceX = objective.transform.position.x - player.transform.position.x;
        distanceY = objective.transform.position.y - player.transform.position.y;
    }

    void CalculateObjectiveRadarPosition() {
        CalculateObjectiveRadarX();
        CalculateObjectiveRadarY();
    }

    void CalculateObjectiveRadarX() {
        if (Mathf.Abs(distanceX) < radarRange) {
            objectiveRadarPositionX = (distanceX / radarRange) * (radarPosition.rect.width / 2);
        } else {
            objectiveRadarPositionX = (radarPosition.rect.width / 2) * Mathf.Sign(distanceX);
        }
    }

    void CalculateObjectiveRadarY() {
        if (Mathf.Abs(distanceY) < radarRange) {
            objectiveRadarPositionY = (distanceY / radarRange) * (radarPosition.rect.height / 2);
        } else {
            objectiveRadarPositionY = (radarPosition.rect.height / 2) * Mathf.Sign(distanceY);
        }
    }

    void SetObjectiveRadarPosition() {
        objectiveRadarPosition.localPosition = new Vector2(objectiveRadarPositionX, objectiveRadarPositionY);
    }
}
