using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    #region Variables
    SpriteRenderer spriteRenderer;
    BlinkMove blink;
    Hotkeys hotkeys;
    int playerLifes = 3;
    bool facingRight = true;
    Vector3 checkpoint;
    #endregion

    void Start() {
        checkpoint = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        blink = GetComponent<BlinkMove>();
        hotkeys = GameObject.Find("_SCRIPTS_")
            .GetComponent<Hotkeys>();
    }

    void Update() {
        hotkeys.CheckKeys();
        blink.BlinkController();
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Platform") {
            transform.parent = other.transform;
        }
    }

    void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.tag == "Platform") {
            transform.parent = null;
        }
    }

    public void SetColor(Color color) {
        spriteRenderer.color = color;
    }
    
    public void SetPosition(Vector3 position) {
        transform.position = position;
    }

    public Vector3 GetPosition() {
        return transform.position;
    }

    public bool IsFacingRight() {
        return facingRight;
    }

    public void Flip() {
        if (!blink.IsBlinking()) {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    public void TakeDmg() {
        if (playerLifes <= 0) {
            //Game Over
        } else {
            //playerLifes--;
            //LifeColor(playerLifes);
            transform.position = checkpoint;
        }
    }


    //void LifeColor(int lifes) {
    //    switch (lifes) {
    //        case 3:
    //            GetComponent<SpriteRenderer>().color = Color.white; break;
    //        case 2:
    //            GetComponent<SpriteRenderer>().color = Color.yellow; break;
    //        case 1:
    //            GetComponent<SpriteRenderer>().color = Color.red; break;
    //        default:
    //            GetComponent<SpriteRenderer>().color = Color.black; break;
    //    }
    //}

    public void CPUpdate(Vector3 newPosition) {
        checkpoint = newPosition;
    }
}
