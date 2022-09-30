using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour {

    // Config
    //

    [SerializeField]
    string gameScene;

    [SerializeField]
    TMP_InputField roomIdField;

    //
    // \Config

    Hathora.Client hathoraClient;

    void Awake() {
        hathoraClient = Hathora.Client.GetInstance();
    }

    private void GoToGameScene() {
        SceneManager.LoadScene(gameScene);
    }

    // Public Methods
    //

    public async void CreateNewGame() {
        Debug.Log("CREATE");
        await hathoraClient.CreateNewGame();
        GoToGameScene();
    }

    public void JoinGame() {
        string roomId = roomIdField.text;

        if (roomId != "") {
            Debug.Log("JOIN: " + roomIdField.text);
            hathoraClient.JoinGame(roomId);
            GoToGameScene();
        }
    }
}