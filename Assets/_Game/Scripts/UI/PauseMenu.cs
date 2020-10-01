using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {
    private static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    void Start() {
        //no longer needed because player will now be ported to lobby
        //GameManager.Instance.DeathEvent += deathEventListener;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GameIsPaused) {
                Resume();
            }
            else {
                Pause();
            }
        }
    }

    private void deathEventListener(GameObject obj) {
        Debug.Log("ACTION");
        if (obj.CompareTag("Player")) {
            Pause();
            Text[] buttonTexts = this.GetComponentsInChildren<Text>();
            Debug.Log(buttonTexts.Length);
            foreach (var text in buttonTexts) {
                if (text.text == "Continue") {
                    text.text = "You died!";
                }
            }
        }
    }

    private void Pause() {
        Cursor.visible = true;
        Time.timeScale = 0;
        pauseMenuUI.SetActive(true);
        GameIsPaused = true;
    }

    private void Resume() {
        Cursor.visible = false;
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
    }

    public void LoadMenu() {
        SceneManager.LoadScene("BenTestMenu");
    }

    public void QuitGame() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}