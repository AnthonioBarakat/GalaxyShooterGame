using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipMovement : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 5f;

    private float movementX, movementY;

    public ScreenBounds screenbounds;

    [SerializeField]
    private GameObject[] projectiles;
    private int randomIndex;

    private GameObject weap;

    private int currentHealth, maxHealth = 100;

    

    private void Awake()
    {
        currentHealth = maxHealth;
        
        
    }
    // Start is called before the first frame update
    void Start()
    {
        HealthBar.SetHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        CheckHealthPlayer();
        ShipMovement();
        ShipFire();
    }

    public float MoveForce
    {
        get { return moveForce; }
        set { this.moveForce = value; }
    }

    void ShipFire()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            randomIndex = Random.Range(0, projectiles.Length);
            weap = Instantiate(projectiles[randomIndex]);
            weap.transform.position = this.transform.position;
        }
    }

    void ShipMovement()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        movementY = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(movementX, movementY, 0f) * moveForce * Time.deltaTime;




        Vector2 input = new Vector2(movementX, movementY);
        input.Normalize();
        Vector3 velocity = moveForce * input;

        Vector3 temPosition = transform.localPosition + velocity * Time.deltaTime;


        if (screenbounds.AmIOutOfBounds(temPosition))
        {
            Vector2 newPosition = screenbounds.CalculateWrappedPosition(temPosition);
            transform.position = newPosition;
        }
        else
        {
            transform.position = temPosition;
        }

    }

    void CheckHealthPlayer()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerProjectile") || collision.gameObject.CompareTag("ScreenBound"))
        {
            //Debug.Log("Safe");
        }
        //else if (collision.gameObject.CompareTag("EnemyProjectile"))
        //{
        //    Debug.Log("Enemy Projectile");
        //}
        else
        {
            currentHealth -= 25;
            Destroy(collision.gameObject);
            HealthBar.SetHealth(currentHealth);
            //healthBar.SetHealth(currentHealth);
        }
    }
}
