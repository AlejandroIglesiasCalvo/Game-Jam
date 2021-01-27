using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cofre : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody2D;
    private GameObject colisionado;
    private Rigidbody2D aux ;
    private bool mostrar=false;//Para ver si se esta mostrando ya
    public Image Nota;//La nota a mostrar
    public RectTransform posNota; //Donde se muestra
    public Canvas MyCanvas; //El canvas
    private Image newNota; //El objeto que se crea y destruye 
    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        aux = colisionado.GetComponent<Rigidbody2D>();
        if(colisionado.tag == "Protagonista"){
            if (aux && mostrar==false)
            {
            MostrarNota();
            }  
        }
    }
    private void MostrarNota(){
        mostrar=true;
        Transform pN = posNota;
        newNota = Instantiate(Nota, pN.position, Quaternion.identity);
        newNota.transform.parent = MyCanvas.transform;
        pN.position = new Vector2(pN.position.x, pN.position.y);
    }
    private void QuitarNota(){
        Destroy (GameObject.FindWithTag("Nota"));
        mostrar==false;
    }
     private void OnCollisionEnter2D(Collision2D collision)
    {
        colisionado = collision.gameObject;
    
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        colisionado = null;
        QuitarNota();
    }
}
