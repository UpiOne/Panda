using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tween : MonoBehaviour
{
    public float time;
    public LeanTweenType type;
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.scale(gameObject, new Vector3(0, 0, -10), time).setEase(type).setLoopType(type);
    }

}
