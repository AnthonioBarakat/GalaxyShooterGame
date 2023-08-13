using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // ^^


public class SpeedBar : MonoBehaviour
{
    private Slider slider;
    private PlayerShipMovement player;

    private float oldSpeed;

    [SerializeField]
    private GameObject speedEffect;
    private GameObject instSpeedEffect;
    

    public void Awake()
    {
        slider = GetComponent<Slider>();
        player = GameObject.FindWithTag("Player").GetComponent<PlayerShipMovement>();
        oldSpeed = player.MoveForce;
    }

    public void SpeedButtonClicked()
    { 
        if (Input.GetKeyDown(KeyCode.LeftAlt) && slider.maxValue == slider.value)
        {
            slider.value = 0;
            // Add speed
            player.MoveForce = 15f;
            if (instSpeedEffect == null)
            {
                instSpeedEffect = Instantiate(speedEffect);
            }
            StartCoroutine(RegenerateSpeed());
        }
    }

    IEnumerator RegenerateSpeed()
    {
        yield return new WaitForSeconds(6);
        Destroy(instSpeedEffect);
        player.MoveForce = oldSpeed;
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
        SpeedButtonClicked();
        instSpeedEffect.transform.position = new Vector2(player.transform.position.x, player.transform.position.y -1f);
    }
}
