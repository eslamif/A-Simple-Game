using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float jumpSpeed = 20f;

    private Rigidbody rb;
    private Vector3 inputVector;
    private bool jump = false;
    private Game game;

    void Start() {
        rb = GetComponent<Rigidbody>();
        game = GameObject.FindObjectOfType<Game>();
    }

    void Update() {
        Move();
        Jump();
    }

    private void FixedUpdate() {
        rb.velocity = inputVector;

        if (jump && isGrounded()) {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            jump = false;
        }
    }

    private void Move() {
        inputVector = new Vector3(Input.GetAxis("Horizontal") * movementSpeed, rb.velocity.y, Input.GetAxis("Vertical") * movementSpeed);
        transform.LookAt(transform.position + new Vector3(inputVector.x, 0, inputVector.z));
    }

    private void Jump() {
        if (Input.GetButtonDown("Jump")) {
            jump = true;
        }
    }

    private bool isGrounded() {
        float distance = GetComponent<Collider>().bounds.extents.y + 0.01f;
        Ray ray = new Ray(transform.position, Vector3.down);
        return Physics.Raycast(ray, distance);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            game.ReloadCurrentScene();
        }
    }
}
