using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    [SerializeField] private AudioSource Gameover;
    public GameObject GameOverMenu;
    // Start is called before the firs
    // t frame update
    
    private void OnEnable()
    {
        KillPlayer.Death += EnableGameOverMenu;
    }
    private void OnDisable()
    {
        KillPlayer.Death -= EnableGameOverMenu;
    }
    public void EnableGameOverMenu()
    {
        GameOverMenu.SetActive(true);
        Gameover.Play();
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
}
