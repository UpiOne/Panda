using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    Spawner speed;
    [SerializeField] private GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        speed = FindObjectOfType<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {
      
        Destroy(this.gameObject, 10f);
        transform.Translate(Vector2.down * speed.speed);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().Hp -= damage;
            Destroy(gameObject);
        }
        if (other.CompareTag("ed"))
        {

            Instantiate(prefab, transform.position, Quaternion.identity);
        }
    }
}
