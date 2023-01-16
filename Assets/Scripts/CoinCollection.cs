using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CoinCollection : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform target;
    // public Transform intial;
    [SerializeField] private GameObject CoinPrefab;
    [SerializeField] private Camera cam;

    void Start()
    {
     
        if (cam == null)
        {
            cam = Camera.main;
        }
        
    }

    public void StartCoinMove(Vector3 _intial)
    {
        // Vector3 intialpos = cam.ScreenToWorldPoint(new Vector3(intial.position.x, intial.position.y, cam.transform.position.z * -1));
        Vector3 targetpos = cam.ScreenToWorldPoint(new Vector3(target.position.x, target.position.y, cam.transform.position.z * -1));
        GameObject coim = Instantiate(CoinPrefab, transform);
      
        StartCoroutine(MoveCoin(coim.transform, _intial, targetpos)); 
    }
     IEnumerator MoveCoin(Transform obj,Vector3 startPos,Vector3 endPos)
    {
        float time = 0;

        while (time < 1)
        {
            
            time += speed * Time.deltaTime;
            obj.position = Vector3.Lerp(startPos, endPos, time);
           
            yield return new WaitForEndOfFrame();
        }
        
        Destroy(obj.gameObject);
    }
}
