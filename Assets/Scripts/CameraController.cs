using UnityEngine;

public class CameraController : MonoBehaviour {
    GameObject player;

    void Start() {
        player = GameObject.Find("Player");
    }

    void LateUpdate() {
        FollowPlayer();
    }

    void FollowPlayer() {
        float cameraPositionX;
        float cameraPositionY;
        float currentVelocityX  = 0f;
        float currentVelocityY  = 0f;
        float smoothTime = 7f * Time.deltaTime;

        cameraPositionX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x,
            ref currentVelocityX , smoothTime);
        cameraPositionY = Mathf.SmoothDamp(transform.position.y, (player.transform.position.y - 0.5f),
            ref currentVelocityY, smoothTime);
        transform.position = new Vector3(cameraPositionX, cameraPositionY, transform.position.z);
    }

    public void AdjustCamera() {
        transform.position = new Vector3(
            player.transform.position.x, player.transform.position.y, transform.position.z);
    }
}