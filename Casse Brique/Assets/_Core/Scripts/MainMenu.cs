using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private int niveau = 1; 
    [SerializeField]
    private int score = 0;
    [SerializeField]
    private int lives = 3;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    } 
    private void Start()
    {
        NouvellePartie();
    }
    private void NouvellePartie()
    {
        this.score = 0;
        this.lives = 3;

        LoadLevel(1);


    }
    private void LoadLevel(int niveau)
    { 
        this.niveau = niveau;
        SceneManager.LoadScene("Niveau" + niveau);
    }
   
}
