using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

    private int requiredCoins;
    private Game game;

    void Start() {
        requiredCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
        game = GameObject.FindObjectOfType<Game>();
    }

    public void CheckForCompletion(int coinsCollected) {
        if (coinsCollected >= requiredCoins) {
            game.LoadNextScene();
        }
        else {
            Debug.Log("You need more coins!");
        }
    }
}
