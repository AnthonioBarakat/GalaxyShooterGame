using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectils : MonoBehaviour
{
    public float speed = 15f;

    [SerializeField]
    BoxCollider2D screenBoundsbox;

    // Start is called before the first frame update
    void Start()
    {
        screenBoundsbox = GameObject.FindWithTag("ScreenBound").GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;

        if (transform.position.y >= screenBoundsbox.bounds.max.y)
        {
            // Destroy the bullet.
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
