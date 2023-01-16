using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private float endX;
    [SerializeField] private float startX;

    void Update()
    {
        int randX = Random.Range(2, 14);
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if(transform.position.x <= endX)
        {
            Vector2 pos = new Vector2(randX, transform.position.y);
            transform.position = pos;
        }
    }
}
