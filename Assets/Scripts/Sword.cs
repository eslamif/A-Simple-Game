using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {
    [SerializeField] private float attackDuration = 0.5f;
    private float attackDurationTimer;

    private void Start() {
        attackDurationTimer = attackDuration;
    }

    void Update() {
        attackDurationTimer -= Time.deltaTime;

        if (attackDurationTimer <= 0) {
            gameObject.SetActive(false);
            attackDurationTimer = attackDuration;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Enemy")) {
            Destroy(other.gameObject);
        }
    }
}
