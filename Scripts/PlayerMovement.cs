using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] private float speed = 10f;
    
    private Animator anim;
    private Rigidbody2D body;
    private float horizontalInput = 0f;

    private void Awake() {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update() {
        horizontalInput = Input.GetAxis("Horizontal");
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) {
            body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);
        }

        //Flip the model from right to left and vice versa
        if(horizontalInput > 0.01f) {
            //Keep untouched
            transform.localScale = Vector3.one;

        } else if(horizontalInput > -0.01f) {
            //Change vector
            transform.localScale = new Vector3(-1, 1, 1);

        }

        if(Input.GetKey(KeyCode.UpArrow)) {
            body.linearVelocity = new Vector2(body.linearVelocity.x, speed);
        }

        //Change animation rule
        anim.SetBool("running", horizontalInput != 0);
        
    }

}