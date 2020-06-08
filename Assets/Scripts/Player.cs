using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private float movementSpeed = 5f;

    private Rigidbody rb;
    private Vector3 inputVector;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        inputVector = new Vector3(Input.GetAxis("Horizontal") * movementSpeed, rb.velocity.y, Input.GetAxis("Vertical") * movementSpeed);
        transform.LookAt(transform.position + new Vector3(inputVector.x, 0, inputVector.z));
    }

    private void FixedUpdate() {
        rb.velocity = inputVector;
    }
}
