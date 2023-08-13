using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
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
        transform.position += Vector3.down * speed * Time.deltaTime;

        if (transform.position.y <= screenBoundsbox.bounds.min.y)
        {
            // Destroy the bullet.
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collide");
        Destroy(gameObject);
    }

}
