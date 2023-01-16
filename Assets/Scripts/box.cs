using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{
   [SerializeField] private GameObject prefab;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Gear"))
        {
            
            Instantiate(prefab,transform.position,Quaternion.identity);
           // Destroy(gameObject);
        }
    }
}
