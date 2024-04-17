using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartUI : MonoBehaviour
{
    [SerializeField]
    private Player_Manager PlayerManager;

    private void Awake()
    {
        PlayerManager = GetComponent<Player_Manager>();
        gameObject.SetActive(false);
    }

    private void Start()
    {

    }

    public void onClickRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    public void onClickQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else

        Application.Quit();
#endif

    }

    
}
