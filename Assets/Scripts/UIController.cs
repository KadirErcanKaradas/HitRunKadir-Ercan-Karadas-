using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] public Transform restart;

    public void Restart()
    {
        restart.gameObject.SetActive(true);
        OnClicked();
        
    }
    private void OnClicked()
    {
        SceneManager.LoadScene(0);
    }
}
