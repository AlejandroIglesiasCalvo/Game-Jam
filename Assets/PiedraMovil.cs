using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiedraMovil : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody2D;
    private GameObject colisionado;
    private Rigidbody2D aux ;
    private double tMovimiento;//Tiempo que se puede "deslizar"
    // Start is called before the first frame update
    void Start()
    {
       m_Rigidbody2D = GetComponent<Rigidbody2D>(); 
       tMovimiento=5;
    }

    // Update is called once per frame
    void Update()
    {
        aux = colisionado.GetComponent<Rigidbody2D>();
        if (aux)
        {
            Moverse();
            tMovimiento--;
        }
        if(tMovimiento==0){
             m_Rigidbody2D.velocity = new Vector2(0f,0f);//que se pare
        }
    }
     private void FixedUpdate()
    {
        Moverse();
    }
    private void Moverse()
    {    
        m_Rigidbody2D.velocity =aux.velocity;
        tMovimiento++; //Para que empieze a contar al soltar el objeto
        aux=null;
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
