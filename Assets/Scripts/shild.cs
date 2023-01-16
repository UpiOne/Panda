using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shild : MonoBehaviour
{

    public float cooldown;
    public bool isCooldown;
    public Image shield;
    public Collider2D colliders;
    // Start is called before the first frame update
    void Start()
    {
        shield = GetComponent<Image>();
        colliders = FindObjectOfType<Player>().GetComponent<Collider2D>();
        isCooldown = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (isCooldown)
        {
            colliders.enabled = false;

            shield.fillAmount -= 1 / cooldown * Time.deltaTime;
            if (shield.fillAmount <= 0)
            {
               
                shield.fillAmount = 1;
                
                isCooldown = false;
               
                gameObject.SetActive(false); colliders.enabled = true;
            }
          
        }

    }

}
