using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public int Hp = 1;
    public int hscore;
    public int score = 0;
    [SerializeField] private Vector2 targetPos;
    [SerializeField] private float Xincrement;
    [SerializeField] private float speed;
    [SerializeField] private float maxHeight;
    [SerializeField] private float minHeight;

    [SerializeField] private Text text;
    [SerializeField] private Text scores1;
    [SerializeField] private TextMeshProUGUI hscores1;

    [SerializeField] private GameObject die;
    [SerializeField] private GameObject UI;
    [SerializeField] private GameObject spawner;
    [SerializeField] private GameObject parralax;
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject prefab1;
    [SerializeField] private GameObject textStart;
    Spawner sp;
    ManagerAudio ma;
    public TextMeshProUGUI bagtext;

    private Animation anim;
    // Start is called before the first frame update
    void Start()
    {
      
        anim = this.GetComponent<Animation>();
        sp = FindObjectOfType<Spawner>();
        ma = FindObjectOfType<ManagerAudio>();
        sp.enabled = false;
        hscores1.text ="Max: "+ PlayerPrefs.GetInt("hs").ToString();
      
    }
    // Update is called once per frame
    void Update()
    {
      
      
        if (Input.GetMouseButtonDown(0))
        {
           // Time.timeScale = 1;
           
            sp.enabled = true;
            textStart.SetActive(false);
        }
      
        hscore = score;
        if(hscore > PlayerPrefs.GetInt("hs"))
        {
            PlayerPrefs.SetInt("hs", hscore);
            hscores1.text = "Score/HighScore: "+hscore.ToString()+"/"+ PlayerPrefs.GetInt("hs").ToString();
        }
      
        text.text = "HP: " + Hp;
        scores1.text = "Score: " + score;
      
        if (Hp <= 0)
        {
            ma.PlaySound(1);
            prefab.SetActive(true);
            spawner.SetActive(false);
            parralax.SetActive(false);
            UI.SetActive(false);
            die.SetActive(true);
            Destroy(this.gameObject);
        }
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
     
        if (Input.GetKeyDown(KeyCode.A) && transform.position.x > minHeight)
        {
           
            targetPos = new Vector2(transform.position.x - Xincrement, transform.position.y);
            Instantiate(prefab1, transform.position, Quaternion.identity);
            ma.PlaySound(0);

        }
        if (Input.GetKeyDown(KeyCode.D) && transform.position.x < maxHeight)
        {
           
            targetPos = new Vector2(transform.position.x + Xincrement, transform.position.y );
            Instantiate(prefab1,transform.position,Quaternion.identity);
            ma.PlaySound(0);
        }
        if(transform.position.x > 1.5 )
        {
            StartCoroutine(textbags());
            targetPos = new Vector2(0, transform.position.y);
           
        }
        if (transform.position.x < -1.5)
        {
            StartCoroutine(textbags());
            targetPos = new Vector2(0, transform.position.y);

        }
       
    }

    

    IEnumerator textbags()
    {
        bagtext.enabled = true;
        bagtext.text = "Not so fast !!!";
        yield return new WaitForSeconds(1f);
        bagtext.enabled = false;
    }
    public void leftMove()
    {
        if (transform.position.x > minHeight  )
        {
            anim.Play("Move-Left");
            targetPos = new Vector2(transform.position.x - Xincrement, transform.position.y);
         
            Instantiate(prefab1, transform.position, Quaternion.identity);
            ma.PlaySound(0);
        }
    }
    public void rightMove()
    {
        if ( transform.position.x < maxHeight )
        {
            anim.Play("Move-Right");
            targetPos = new Vector2(transform.position.x + Xincrement, transform.position.y);
         
            Instantiate(prefab1, transform.position, Quaternion.identity);
            ma.PlaySound(0);
        }
    }

    

}

