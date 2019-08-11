using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    #region Variables
    Rigidbody2D rigidBody;
    const float speed = 3.6f; //Player's speed
    float velocityX;
    const float jumpSpeed = 12f;
    Vector2 jumpVector = new Vector2(0f, 550f);
    bool jumped = false;
    bool grounded = false;
    bool grounded_prev = false;
    float groundRadius = 0.05f; //Poin't radius
    [SerializeField]
    Transform groundCheck; //Contact verification point
    [SerializeField]
    LayerMask groundLayer;
    Player movingPlayer;
    BlinkMove blink;
    PlayerAnimator playerAnimator;
    PlayerAudio playerAudio;
    Hotkeys hotkeys;
    #endregion

    void Start() {
        movingPlayer = GetComponent<Player>();
        blink = GetComponent<BlinkMove>();
        rigidBody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<PlayerAnimator>();
        playerAudio = GetComponent<PlayerAudio>();
        hotkeys = GameObject.Find("_SCRIPTS_")
            .GetComponent<Hotkeys>();
    }

    private void Update() {
        Jump();
    }

    void FixedUpdate() {
        Movement();
    }

    void Movement() {
        //float horizontal = Input.GetAxis("Horizontal");
        CheckGrounded();
        velocityX = rigidBody.velocity.x;
        if (blink.IsBlinking()) {
            velocityX = 0;
        } else if (hotkeys.IsRightPressed()) {
            velocityX = speed;
        } else if (hotkeys.IsLeftPressed()) {
            velocityX = -speed;
        } else {
            velocityX = 0f;
        }
        if (ChangesDirection()) {
            movingPlayer.Flip();
        }
        if (jumped == true) {
            rigidBody.AddForce(jumpVector);
            jumped = false;
        }
        rigidBody.velocity = new Vector2(velocityX, rigidBody.velocity.y);
        //rigidBody.velocity = new Vector2(velocityX * speed, rigidBody.velocity.y);
    }

    void Jump() {
        if (hotkeys.IsJumpPress()&& grounded && !blink.IsBlinking()) {
            jumped = true;
            playerAnimator.TriggerJumpAnimation();
            playerAudio.PlayJumpAudio();
        }
    }

    public void FreezePlayer(bool state) {
        if (state) {
            rigidBody.isKinematic = true;
            rigidBody.velocity = Vector2.zero;
            playerAudio.SetWalkAudio(false);
            playerAnimator.SetBlinkAnimation(true);
        } else {
            rigidBody.isKinematic = false;
            playerAudio.SetWalkAudio(true);
            playerAnimator.SetBlinkAnimation(false);
        }
    }

    public bool JustLanded() {
        return (!grounded_prev && grounded);
    }

    public bool IsGrounded() {
        return grounded;
    }

    public float GetVelocityX() {
        return velocityX;
    }

    void CheckGrounded() {
        grounded_prev = grounded;
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);
    }

    bool ChangesDirection() {
        return ((velocityX < 0f && movingPlayer.IsFacingRight())||
            (velocityX > 0f && !movingPlayer.IsFacingRight()));
    }
}