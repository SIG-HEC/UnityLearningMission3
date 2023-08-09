using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private TMP_Text nom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayGame()
    {
        if (persistance.Instance != null)
            persistance.Instance.playerName = nom.text;
 
        SceneManager.LoadScene(1);
    }
}
