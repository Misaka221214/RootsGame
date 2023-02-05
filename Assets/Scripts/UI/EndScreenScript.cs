using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreenScript : MonoBehaviour
{
    public Sprite newButtonImage;
    public Button button;

    public void BackMenu()
    {
        SceneManager.LoadScene(0);
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
