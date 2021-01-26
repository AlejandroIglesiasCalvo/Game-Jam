using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody2D;
    private GameObject colisionado;
    private Rigidbody2D aux ;
    public Transform posicion;
    private GameObject orbe;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
         aux = colisionado.GetComponent<Rigidbody2D>();
        if (aux)
        {
           FinNivel();
        }
    }
    private void FinNivel(){
        Instantiate(orbe, posicion.position, posicion.rotation);
        Destroy(this.gameObject); 
    }
     private void OnCollisionEnter2D(Collision2D collision)
    {
        colisionado = collision.gameObject;
    
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        colisionado = null;
    }
}
