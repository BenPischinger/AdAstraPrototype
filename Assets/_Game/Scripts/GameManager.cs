using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    //Can save variables globaly for the whole game without being connected to any GameObject, such as current level or score
    private static GameManager instance = null;

    public static GameManager Instance {
        get { return instance; }
    }

    public GameObject Player { get; set; }
    [SerializeField] public int ArenaScene;
    public int[] AdditionalArenaScenes;
    public int LobbyScene;
    public int[] AdditionalLobbyScenes;

    private bool _inArena = false;

    private int _round = 0;

    //Delegates
    public delegate void DeathHandler(GameObject objectToDie);

    //Events
    public event DeathHandler DeathEvent;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        else if (instance != this) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private GameManager() {
    }


    public void StartRound() {
        Debug.Log("Loading Arena");
        _inArena = true;
        _round++;
        SceneManager.LoadScene(ArenaScene,LoadSceneMode.Single);
        if (AdditionalArenaScenes == null) return;
        foreach (var i in AdditionalArenaScenes) {
            SceneManager.LoadScene(i, LoadSceneMode.Additive);
        }
    }

    public void EndRound() {
        Debug.Log("Loading Lobby");
        _inArena = true;
        SceneManager.LoadScene(LobbyScene,LoadSceneMode.Single);
        if (AdditionalLobbyScenes == null) return;
        foreach (var i in AdditionalLobbyScenes) {
            SceneManager.LoadScene(i, LoadSceneMode.Additive);
        }
    }

    public void invokeDeathEvent(GameObject objectToDie) {
        if (DeathEvent == null) {
            Debug.Log("DeathEvent stopped, no listeners");
            return;
        }

        DeathEvent.Invoke(objectToDie);
    }
}