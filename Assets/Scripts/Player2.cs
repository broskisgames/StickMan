using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    //DATOS
    public string nombre;
    public GameObject player2;

    public Bullet bullet;

    //VIDA
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("shoot", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //DISPARAR
    public void shoot()
    {
        Vector2 direction = (player2.transform.position - transform.position).normalized;
        Bullet newBullet = Instantiate(bullet);
        newBullet.transform.position = new Vector2(transform.position.x, transform.position.y);
        newBullet.initialize(direction, nombre);
    }

    //RECIBIR DISPARO
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet" && collision.gameObject.GetComponent<Bullet>().getPlayer() != nombre)
        {
            healthBar.SetHealth(2f);
        }
    }
}
