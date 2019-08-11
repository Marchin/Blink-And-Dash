using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum MOVEMENT { Horizontal, Vertical };

public class PlatformMovement : MonoBehaviour {
    #region Variables
    [SerializeField]
    MOVEMENT platformDirection;
    [SerializeField]
    float movementDuration;
    [SerializeField]
    float movementLenght;
    [SerializeField]
    [Range(0f, 100f)]
    float initPercentagePosition;
    float currentPercentagePosition;
    float movementUnit;
    float movementRate;
    Vector3 movementDirection;
    #endregion

    void Start() {
        SetupMovement();
        SetDirection();
    }

    void Update() {
        if (movementDuration > 0f) {
            MovePlatform();
        }
    }

    void SetupMovement() {
        currentPercentagePosition = initPercentagePosition;
        movementRate = 100f / movementDuration;
        movementUnit = movementLenght / movementDuration;
    }

    void SetDirection() {
        if (platformDirection == MOVEMENT.Horizontal) {
            movementDirection = Vector3.right;
        } else if (platformDirection == MOVEMENT.Vertical) {
            movementDirection = Vector3.up;
        } else {
            movementDirection = Vector3.zero;
        }
    }

    void MovePlatform() {
        if (currentPercentagePosition >= 0f && currentPercentagePosition <= 100f) {
            currentPercentagePosition += movementRate * Time.deltaTime;
            transform.position += movementDirection * movementUnit * Time.deltaTime;
        } else {
            ChangeDirection();
        }
    }

    void ChangeDirection() {
        if (movementUnit > 0f) {
            currentPercentagePosition = 100f;
        }else {
            currentPercentagePosition = 0f;
        }
        movementUnit = -movementUnit;
        movementRate = -movementRate;
    }
}
