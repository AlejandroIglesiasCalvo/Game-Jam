using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed = 40f;
    public float horizontalMove = 0f;
    public float verticalMove = 0f;
    private Rigidbody2D m_Rigidbody2D;
    private GameObject colisionado;
    private Animator anims;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        anims = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove=Input.GetAxisRaw("Horizontal");
        verticalMove=Input.GetAxisRaw("Vertical");
        
        if (Input.GetKeyDown(KeyCode.E)&&colisionado)
        {
            InteractuAR aux = colisionado.GetComponent<InteractuAR>();
            if (aux)
            {
                aux.Interactuar();
            }
        }
    }

    private void FixedUpdate()
    {
        Moverse();
    }
    private void Moverse()
    {
        if (horizontalMove >0)
        {
            anims.SetInteger("moveType", 2);
           
            anims.SetInteger("direction", 4);
        }
        else
        {
             anims.SetInteger("moveType", 1);

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
