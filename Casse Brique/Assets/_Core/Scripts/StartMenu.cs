using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    [SerializeField]
    private int niveau = 1;

//Fonctions use for start a new game or quit the game.
    public void NewLevel(int niveau)
    {
        this.niveau = niveau;
        SceneManager.LoadScene("Niveau" + niveau);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
