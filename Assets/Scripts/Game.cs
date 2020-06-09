using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {
    [SerializeField] private int currentScene;
    [SerializeField] private bool lastScene;

    private int nextScene;

    void Start() {
        nextScene = currentScene + 1;
    }

    public void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void ReloadCurrentScene() {
        LoadScene("Level-" + currentScene);
    }

    public void LoadNextScene() {
        if (!lastScene) {

            string sceneName = "Level-" + nextScene;
            LoadScene(sceneName);
        }
    }

    public void Quit() {
        Application.Quit();
    }
}
