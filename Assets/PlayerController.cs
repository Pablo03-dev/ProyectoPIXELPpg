using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3;
    public float jump = 7;
    public GameObject particulaSalto;
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer sr;
    private bool jumping;
    bool walkingRight;
    bool walkingLeft;
    //private bool colliding;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            //transform.position -= transform.right * speed * Time.deltaTime;
            //rb.MovePosition(rb.position + Vector2.left * speed * Time.deltaTime);
            anim.SetBool("walking", true);
            walkingLeft = true;
            walkingRight = false; //super desordenado pero esto es codigo rapido
            sr.flipX = true;
            //anim.Play("Walk");
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            //transform.position += transform.right * speed * Time.deltaTime;
            //rb.MovePosition(rb.position + Vector2.right * speed * Time.deltaTime);
            anim.SetBool("walking", true);
            walkingRight = true;
            walkingLeft = false;
            sr.flipX = false;
            //anim.Play("Walk");
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            //transform.position += transform.up * jump * Time.deltaTime; //NO USAR TRANSFORM SI ES USA RIGIDBODY,
            //es uno o el otro pero no hay que mezclar los dos. Sé que es algo rápido o pequeño
            //rb.AddForce(Vector2.up * jump); //mejor hacerlo funcionar de forma similar igual
            //rb.velocity = Vector2.up * jump * Time.deltaTime; //movido a fixedupdate
            jumping = true;
            anim.SetBool("grounded", false);
            particulaSalto.SetActive(true);
        }
        else
        {
            jumping = false;
        }

        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.RightArrow) 
            && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetBool("walking", false);
            walkingRight = false;
            walkingLeft = false;
        }

        if (rb.velocity.y > 0f)
        {
            anim.SetBool("ascending", true);
        }
        else if (rb.velocity.y < 0f)
        {
            anim.SetBool("ascending", false);
        }

        if (rb.velocity.y > 0.1f || rb.velocity.y < -0.1f)
        {
            anim.SetBool("grounded", false);
        }
        else
        {
            anim.SetBool("grounded", true);
        }
        /*Debug.DrawLine(rb.position, rb.position + Vector2.down * 0.55f);
        if (Physics.Raycast(rb.position, Vector2.down, Mathf.Infinity, out ControllerCo))
        {
            anim.SetBool("grounded", true);
        }
        else
        {
            anim.SetBool("grounded", false);
        }*/
    }

    private void FixedUpdate()
    {
        //para que el salto se vea mejor procesar movimiento en fixedupdate

        Vector2 moveVector = new Vector2(0f, rb.velocity.y);
        if (jumping)
        {
            //rb.velocity = Vector2.up * jump * Time.deltaTime;
            moveVector.y = 1 * jump * Time.deltaTime;
        }
        if (walkingRight)
        {
            //rb.MovePosition(rb.velocity + (rb.position + Vector2.right * speed * Time.deltaTime));
            moveVector.x = 1 * speed * Time.deltaTime;
        }
        if (walkingLeft)
        {
            //rb.MovePosition(rb.velocity + (rb.position + Vector2.left * speed * Time.deltaTime));
            moveVector.x = -1 * speed * Time.deltaTime;
        }
        rb.velocity = moveVector;
    }

    /*private void OnCollisionStay(Collision collision)
    {
        //colliding = true;
        anim.SetBool("grounded", true);
    }*/
    /*private void OnCollisionEnter(Collision collision)
    {
        anim.SetBool("grounded", true);
    }*/
    /*private void OnCollisionExit(Collision collision)
    {
        //colliding = false;
        anim.SetBool("grounded", false);
    }*/
}
