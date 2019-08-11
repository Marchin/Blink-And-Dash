using System.Collections; using System.Collections.Generic; using UnityEngine;  public class JumpPlatform : MonoBehaviour {     Rigidbody2D playerRigidBody;     Vector2 playerJumpVector = new Vector2(0, 850f);     Vector2 resetVelocityY;     public AudioSource bounceAudio;

    void Start() {         playerRigidBody = GameObject.Find("Player")             .GetComponent<Rigidbody2D>();     }


    private void OnTriggerEnter2D(Collider2D collision) {         if (collision.tag == "Player") {
            MakePlayerJump();
        }
    }

    void MakePlayerJump() {
        resetVelocityY = new Vector2(
            playerRigidBody.velocity.x, 0f);
        playerRigidBody.velocity = resetVelocityY;
        playerRigidBody.AddForce(playerJumpVector);
        bounceAudio.Play();
    }
} 