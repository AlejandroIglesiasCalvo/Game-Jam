using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementScript : MonoBehaviour
{
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
    //Hielo
    private bool enHielo;

    //Animaciones
    public Animator animator;
    public LevelLoader loader;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        anims = GetComponent<Animator>();
        enHielo = false;
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
        if (horizontalMove == 0)
        {
            verticalMove = Input.GetAxisRaw("Vertical");
        }
        else
        {
            verticalMove = 0;
        }

        if (Input.GetKeyDown(KeyCode.E)&&colisionado)
        {
            //InteractuAR aux = colisionado.GetComponent<InteractuAR>();
            //if (aux)
            //{
//aux.Interactuar();

            //}
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
       
        if(colisionado.tag == "Hielo"){
            enHielo=true;
        }

    }

    private void FixedUpdate()
    {
        Moverse();
    }
    private void Moverse()
    {
        if (m_Rigidbody2D.velocity == Vector2.zero && enHielo)
        {
            
            Vector2 direccion = new Vector2(horizontalMove, verticalMove);

            m_Rigidbody2D.velocity = direccion * Time.fixedDeltaTime * runSpeed * 4;
            Debug.Log(m_Rigidbody2D.velocity);
        }
        else if (enHielo )
        {
            m_Rigidbody2D.AddForce(new Vector2(horizontalMove, verticalMove));
            

        }
        else
        {
            Vector2 direccion = new Vector2(horizontalMove, verticalMove);

            m_Rigidbody2D.velocity = direccion * Time.fixedDeltaTime * runSpeed * 7;
        }
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
    private void OnTriggerEnter2D(Collider2D col)
    {
        
        Debug.Log("ENTRAR" + col.name);

        if (col.name.Equals("PasaEscena"))
            loader.LoadNextLevel();
        else
        {
            enHielo = true;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("SALIR" + col.name);
        enHielo = false;
    }

}
