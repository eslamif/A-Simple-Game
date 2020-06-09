using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour {
    private GameObject menuPanel;

    private void Start() {
        menuPanel = transform.GetChild(0).gameObject;
    }

    void Update() {
        if (Input.GetButtonDown("GameMenu")) {
            menuPanel.SetActive(!menuPanel.activeSelf);
        }
    }
}
