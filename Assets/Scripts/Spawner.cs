using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Spawner : MonoBehaviour
{
    public GameObject[] gear;
    public float speed;
    public Slider img;
    public float timeBtwSpawn;
    public float startTimeBtwSpawn;
    public float decreaseTime;
    public float minTime;

    public Gradient gr;
    public Image fill;
 
    public int numberWave;
    public int hsnubWave;
    public TextMeshProUGUI textWave;
    public TextMeshProUGUI textMintime;
    public TextMeshProUGUI textSpeed;

    public TextMeshProUGUI hstextWave;


    public GameObject hpPrefab;

    public GameObject winUI;

    public GameObject spawner;
   public Collider2D pl;

    
 
    // Start is called before the first frame update
    void Start()
    {
        
        hstextWave.text = "MaxWave: "+PlayerPrefs.GetInt("Wave").ToString();
    }

    // Update is called once per frame
    void Update()
    {
      
        if (numberWave > PlayerPrefs.GetInt("Wave"))
        {
            PlayerPrefs.SetInt("Wave", numberWave);
            hstextWave.text ="Wave/MaxWave: "+ numberWave.ToString()+ "/"+PlayerPrefs.GetInt("Wave").ToString();
        }
        textWave.text = "Wave : " + numberWave;
        textMintime.text = "Time : " + minTime;
        textSpeed.text = "SpeedGear : " + speed;
        
        
            if (timeBtwSpawn <= 0)
            {
                int rand = Random.Range(0, gear.Length);
                Instantiate(gear[rand], transform.position, Quaternion.identity);
                timeBtwSpawn = startTimeBtwSpawn; numberWave++;
                // SetTime(); 
                if (startTimeBtwSpawn > minTime)
                {

                    startTimeBtwSpawn -= decreaseTime;
                }

            }
            else
            {
                wave();
                timeBtwSpawn -= Time.deltaTime;
            }
        
      
    }
    /*public void SetTime()
    {
        fill.color = gr.Evaluate(1f);
        img.maxValue = startTimeBtwSpawn;
        img.minValue = 0.79f;

        fill.color = gr.Evaluate(img.normalizedValue);
        if(img.minValue < img.maxValue)
        {
            img.value -= decreaseTime;
            img.value = Mathf.Lerp(img.value, img.minValue, decreaseTime);
        }
        else
        {
            img.value -= Time.deltaTime;
        }
    }*/
    public void wave()
    {
         if (numberWave == 10)
         {
             startTimeBtwSpawn = 2;
             minTime = 1.5f;
             speed = 0.06f;
             decreaseTime = 0.05f;
         
        }
         else if (numberWave == 20)
        {
            decreaseTime = 0.01f;
            startTimeBtwSpawn = 1.5f;
             minTime = 1;
             speed = 0.07f;
         } else if (numberWave == 80)
         {
             startTimeBtwSpawn = 1;
             minTime = 1;
             speed = 0.08f;
             decreaseTime = 0.01f;
         }
         else if (numberWave == 140)
        {
            decreaseTime = 0.01f;
            startTimeBtwSpawn = 0.65f;
             minTime = 0.65f;
             speed = 0.09f;

        }
        else if (numberWave == 240)
        {
            decreaseTime = 0.01f;
            startTimeBtwSpawn = 1f;
            minTime = 1f;
            speed = 0.1f;

           
           
        }
        else if (numberWave == 340)
        {
            decreaseTime = 0.01f;
            startTimeBtwSpawn = 1f;
            minTime = 0.75f;
            speed = 0.11f;

        }
        else if (numberWave == 500)
        {
            startTimeBtwSpawn = 1f;
            minTime = 0.65f;
            speed = 0.1f;
            decreaseTime = 0.01f;
            Instantiate(hpPrefab, transform.position, Quaternion.identity);
        }
        else if (numberWave == 1000)
        {
            spawner.SetActive(false);
            winUI.SetActive(true);
           
            pl.enabled = false;
        }


    }
}
