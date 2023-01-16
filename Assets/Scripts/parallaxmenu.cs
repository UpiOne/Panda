using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class parallaxmenu : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private float endX;
    [SerializeField] private float startX;
    [SerializeField] private GameObject prefab;
    private ManagerAudio AudioNotes;
    Player pl;
    [SerializeField] private TextMeshProUGUI hscores1;
    int hscore;
  

    // Start is called before the first frame update
    void Start()
    {
        pl = FindObjectOfType<Player>();
        hscore = pl.hscore;
    }

    // Update is called once per frame
    void Update()
    {

        hscores1.text = PlayerPrefs.GetInt("Wave").ToString();
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(prefab, transform.position, Quaternion.identity);
            FindObjectOfType<ManagerAudio>().PlaySound(0);
            if(AudioNotes !=null)
            AudioNotes.PlaySound(0);
        }
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        if (transform.position.y >= endX)
        {
            Vector2 pos = new Vector2(transform.position.x, startX);
            transform.position = pos;
        }
    }
}