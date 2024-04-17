using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour
{
    [SerializeField]
    private GameObject playerUI;
    private void Start()
    {

    }
    public void onClickPlay()
    {
        SceneManager.LoadScene("Stage1");
        
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
