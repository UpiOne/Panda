using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score : MonoBehaviour
{
    public float speed;
    public int scores;
    public int coinShop;
    public GameObject prefab;
    ManagerAudio ma;
     CoinCollection coin;
    // Start is called before the first frame update
    void Start()
    {
        coinShop = PlayerPrefs.GetInt("coinShop", coinShop);
        ma = FindObjectOfType<ManagerAudio>();
        coin = FindObjectOfType<CoinCollection>();
    }

    void Update()
    {
       
       
        Destroy(this.gameObject, 5f);
        transform.Translate(Vector2.down * speed);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            other.GetComponent<Player>().score += scores;
            coinShop++;
            PlayerPrefs.SetInt("coinShop", coinShop);
            coin.StartCoinMove(other.transform.position);
            ma.PlaySound(2);
            Instantiate(prefab,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
