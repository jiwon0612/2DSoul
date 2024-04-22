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
        //PlayerManager = GetComponent<Player_Manager>();
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    public void onClickRestart()
    { 
        Time.timeScale = 1;
        Debug.Log("restart:" + Time.timeScale);
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
