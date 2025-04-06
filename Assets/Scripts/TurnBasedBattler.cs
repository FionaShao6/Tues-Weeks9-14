using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBasedBattler : MonoBehaviour
{
    public AnimationCurve bigger;
    public Transform hero;
    public float t;
    void Start()
    {
        StartCoroutine(ChangeSize());
    }
    public IEnumerator ChangeSize()
    {
        while (true)
        {
            //hero.localScale= Vector3.one;
            t += Time.deltaTime;
            transform.localScale = Vector2.one * bigger.Evaluate(t);
            yield return null;
        }
    }
    
}
