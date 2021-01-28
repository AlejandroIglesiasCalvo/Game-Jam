using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)|| Input.GetKeyDown(KeyCode.Escape))
        {
            CargaNivel("Menu");
        }


    }

    public void CargaNivel(string NombreNivel){
        SceneManager.LoadScene(NombreNivel);
    }

    public void Salir(){
        Application.Quit();
    }
}
