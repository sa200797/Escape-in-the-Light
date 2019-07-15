using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PannelUI : MonoBehaviour {

    bool isImage1;
    bool isImage2;
    bool isImage3;


    public GameObject pannel;

    public void Image1()
    {
         isImage1 = true;
         isImage2 = false;
        isImage3 = false;

    }

    public void Image2()
    {
        isImage1 = false;
        isImage2 = true;
        isImage3 = false;

    }

    public void Image3()
    {
        isImage1 = false;
        isImage2 = false;
        isImage3 = true;

    }

    public void  NowPlay()
    {
        if(isImage1 == true)
        {
            SceneManager.LoadScene(1);
        }

        if (isImage2 == true)
        {
            SceneManager.LoadScene(4);
        }

        if (isImage3 == true)
        {
            SceneManager.LoadScene(3);
        }

    }

    public void Cancel()
    {
        pannel.SetActive(false);
        Debug.Log("Quit");
    }

    
    // Use this for initialization
    void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
