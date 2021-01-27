using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementScript : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed = 40f;
    public float horizontalMove = 0f;
    public float verticalMove = 0f;
    private Rigidbody2D m_Rigidbody2D;
    private GameObject colisionado;
    private Animator anims;

    //Vida del jugador
    public Image Corazon;
    public int numCorazones;
    public RectTransform PosPrimerCorazon;
    public Canvas MyCanvas;
    public int OffSet;
    public GameObject sonidoDolor;

    //Animaciones
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        anims = GetComponent<Animator>();

        Transform PosCorazon = PosPrimerCorazon;

        //Vida del jugador
        for(int i = 0; i< numCorazones; i++)
        {
            Image NewCorazon = Instantiate(Corazon, PosCorazon.position, Quaternion.identity);
            NewCorazon.transform.parent = MyCanvas.transform;
            PosCorazon.position = new Vector2(PosCorazon.position.x + OffSet, PosCorazon.position.y);
        }
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
        //Si la vida del jugador llega a 0 se muere
        if (numCorazones <= 0)
        {
            Destroy(gameObject);
            Destroy(Corazon);
        }

        //Animaciones
        animator.SetFloat("Horizontal", horizontalMove);
        animator.SetFloat("Vertical", verticalMove);
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

        //Si choca contra un fuego se quema y le quita una vida
        if(colisionado.tag == "Fuego")
        {
            Destroy(MyCanvas.transform.GetChild(numCorazones + 1).gameObject);
            numCorazones -= 1;
            Instantiate(sonidoDolor);
        }
    
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        colisionado = null;
    }
}
