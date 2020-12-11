using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;

    string jugador;

    Vector2 direction;
    Vector2 movement;

    void Start()
    {
        Invoke("destroyBullet", 3f);
    }

    void Update()
    {
        movement = direction * speed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x + movement.x, transform.position.y + movement.y);
    }

    public void initialize(Vector2 dir, string player)
    {
        direction = dir;
        jugador = player;
    }

    void destroyBullet()
    {
        Destroy(gameObject);
    }

    public string getPlayer()
    {
        return jugador;
    }
}
