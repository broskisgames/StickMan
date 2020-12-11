using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : NetworkBehaviour
{
    //DATOS
    string nombre;

    //VIDA
    HealthBar healthBar;

    //MOVIMIENTO
    Joystick joystick;
    public float runSpeed = 5f;
    float horizontalMove = 0f;

    //DISPARAR
    GameObject player2;
    public Bullet bullet;
    bool spawner;

    //SALTO
    Rigidbody2D rb;
    bool isJumping; //Saltar una vez solo

    void Start()
    {
        //INICIALIZAR DATOS
        nombre = gameObject.name;
        healthBar = GameObject.Find("/Canvas/HealthBar").GetComponent<HealthBar>();
        joystick = GameObject.Find("/Canvas/Fixed Joystick").GetComponent<Joystick>();
        player2 = GameObject.Find("/" + nombre);

        //SALTO
        rb = GetComponent<Rigidbody2D>(); //Fisica
        isJumping = false;

        //DISPARAR
        spawner = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
        {
            //MOVIMIENTO LATERAL
            if(joystick.Horizontal >= .2f)
            {
                horizontalMove = -runSpeed;
            }
            else if (joystick.Horizontal <= -.2f)
            {
                horizontalMove = runSpeed;
            }
            else
            {
                horizontalMove = 0;
            }
            transform.position = new Vector2(transform.position.x - horizontalMove * Time.deltaTime, transform.position.y); //Mover

            //SALTO
            if (joystick.Vertical >= .5f && isJumping == false)
            {
                rb.velocity = new Vector3(0, 20, 0);
                isJumping = true;
            }
        }
    }

    //AL TOCAR EL SUELO
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false; //Se puede saltar otra vez
    }

    //DISPARAR
    public void shoot()
    {
        if(spawner == false)
        {
            Vector2 direction = (player2.transform.position - transform.position).normalized;
            Bullet newBullet = Instantiate(bullet);
            newBullet.transform.position = new Vector2(transform.position.x, transform.position.y);
            newBullet.initialize(direction, nombre);
            spawner = true;
            Invoke("resetSpawn", 0.5f);
        }
    }

    private void resetSpawn()
    {
        spawner = false;
    }

    //RECIBIR DISPARO
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet" && collision.gameObject.GetComponent<Bullet>().getPlayer() != nombre)
        {
            healthBar.SetHealth(2f);
        }
    }
}
