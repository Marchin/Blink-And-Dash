using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {
    [SerializeField]
    GameObject shotMatrix;
    GameObject shot;
    Rigidbody2D shotRigidBody;
    float shotSpeed = 3f;
    [SerializeField]
    float shootDownTime = 1f;
    float timeForNextShot;
    const float heighCorrector = 0.25f;

	void Start (){
        timeForNextShot = shootDownTime;
	}

	void Update (){
		if (timeForNextShot <= 0f) {
            InstantiateShot();
            timeForNextShot = shootDownTime;
        } else {
            timeForNextShot -= Time.deltaTime;
        }
	}

    void InstantiateShot() {
        Vector3 shotPosition = transform.position + (transform.up * heighCorrector);
        shot = Instantiate(shotMatrix, shotPosition, transform.rotation);
        shotRigidBody = shot.GetComponent<Rigidbody2D>();
        shotRigidBody.velocity = (transform.up * shotSpeed);
    }
}
