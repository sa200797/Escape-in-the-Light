using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUi : MonoBehaviour {

    public GameObject Ins_Sheet;

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Ins()
    {
        Ins_Sheet.SetActive(true);
    }


    public void Ins_Close()
    {
        Ins_Sheet.SetActive(false);
    }

    public void Start()
    {
        Ins_Sheet.SetActive(false);
    }
}

