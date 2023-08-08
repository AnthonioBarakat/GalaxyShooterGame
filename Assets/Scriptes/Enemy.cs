using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    private GameObject missile;
    private GameObject weap;

    BoxCollider2D screenBoundsbox;


    // Start is called before the first frame update
    void Start()
    {
        screenBoundsbox = GameObject.FindWithTag("ScreenBound").GetComponent<BoxCollider2D>();
        StartCoroutine(EnemyShipFire());
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= screenBoundsbox.bounds.min.y)
        {
            // Destroy the bullet.
            Destroy(gameObject);
        }
    }

   
    IEnumerator EnemyShipFire()
    {
        while (true)
        {

            yield return new WaitForSeconds(Random.Range(1, 3));

            weap = Instantiate(missile);
            weap.transform.position = this.transform.position;
        }

    }
}
