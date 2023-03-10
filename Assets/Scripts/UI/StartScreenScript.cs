using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreenScript : MonoBehaviour
{
    public Sprite newButtonImage;
    public Button button;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ChangeButtonImage()
    {
        button.image.sprite = newButtonImage;
    }
}
