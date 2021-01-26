using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiedraMovil : MonoBehaviour
{

    public float runSpeed = 40f;
    public float horizontalMove = 0f;
    public float verticalMove = 0f;
    private Rigidbody2D m_Rigidbody2D;
    private GameObject colisionado;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     private void FixedUpdate()
    {
        Moverse();


    }
    private void Moverse()
    {
        if (horizontalMove >0)
        {
           
           
            
        }
        else
        {
           

        }
        Vector2 direccion = new Vector2(horizontalMove, verticalMove);
        //direccion=direccion.normalized;
        m_Rigidbody2D.velocity =direccion*Time.fixedDeltaTime*runSpeed;
        

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
