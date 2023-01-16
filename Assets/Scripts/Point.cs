using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    [SerializeField] private GameObject gear;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(gear, transform.position, Quaternion.identity);
    }
}
