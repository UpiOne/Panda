using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHp : MonoBehaviour
{
    public int hp = 1;
    ManagerAudio ma;
    public GameObject prefab;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        ma = FindObjectOfType<ManagerAudio>();
    }

    // Update is called once per frame
    void Update()
    {
      
        Destroy(this.gameObject, 5f);
        transform.Translate(Vector2.down * speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().Hp += hp;
            ma.PlaySound(1);
            Instantiate(prefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
