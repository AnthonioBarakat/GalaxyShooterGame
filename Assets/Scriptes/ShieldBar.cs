using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // ^^


public class ShieldBar : MonoBehaviour
{
    private Slider slider;

    private GameObject player;


    [SerializeField]
    private GameObject shieldEffect;
    private GameObject instShieldEffect;

    public void Awake()
    {
        slider = GetComponent<Slider>();
        player = GameObject.FindWithTag("Player");
    }

    public void ShieldButtonClicked()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && slider.maxValue == slider.value)
        {
            slider.value = 0;
            // Add shield
            if (instShieldEffect == null)
            {
                instShieldEffect = Instantiate(shieldEffect);
            }
            StartCoroutine(ShieldTerminator());
        }
    }

    IEnumerator ShieldTerminator()
    {
        yield return new WaitForSeconds(6);
        Destroy(instShieldEffect);
        for (float i = 0f; i <= slider.maxValue; i += 0.1f)
        {
            yield return new WaitForSecondsRealtime(0.1f);
            slider.value = i;
        }
        slider.value = slider.maxValue;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShieldButtonClicked();
        instShieldEffect.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 0.3f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
    }
}
