using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float jumpSpeed = 20f;
    [SerializeField] private TMPro.TextMeshProUGUI coinsCollectedText;
    private GameObject sword;

    private Rigidbody rb;
    private Vector3 inputVector;
    private bool jump = false;
    private Game game;
    private int coinsCollected;

    void Start() {
        rb = GetComponent<Rigidbody>();
        game = GameObject.FindObjectOfType<Game>();
        sword = transform.GetChild(0).gameObject;
        coinsCollected = 0;
    }

    void Update() {
        GetInput();
    }

    private void FixedUpdate() {
        Move();
        Jump();
    }
    
    private void GetInput() {
        //Move
        inputVector = new Vector3(Input.GetAxis("Horizontal") * movementSpeed, rb.velocity.y, Input.GetAxis("Vertical") * movementSpeed);

        //Jump
        if (Input.GetButtonDown("Jump")) {
            jump = true;
        }

        //Attack
        if (Input.GetButtonDown("SwordAttack")) {
            SwordAttack();
        }
    }

    private void Move() {
        transform.LookAt(transform.position + new Vector3(inputVector.x, 0, inputVector.z));
        rb.velocity = inputVector;
    }

    private void Jump() {
        if (jump && isGrounded()) {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            jump = false;
        }
    }

    private bool isGrounded() {
        float distance = GetComponent<Collider>().bounds.extents.y + 0.01f;
        Ray ray = new Ray(transform.position, Vector3.down);
        return Physics.Raycast(ray, distance);
    }

    private void SwordAttack() {
        if (!sword.activeSelf) {
            sword.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            game.ReloadCurrentScene();
        }
    }

    private void OnTriggerEnter(Collider other) {

        switch (other.tag) {
            case "Coin":
                coinsCollected++;
                coinsCollectedText.text = string.Format("Coins\n{0}", coinsCollected);
                Destroy(other.gameObject);
                break;

            case "Goal":
                other.GetComponent<Goal>().CheckForCompletion(coinsCollected);
                break;

            default:
                break;
        }
    }
}
