using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class KitBird : MonoBehaviour
{
//{using System.Collections;
//using UnityEngine;

    public KitClock clock;            // ����� KitClock ���
    public AnimationCurve appearCurve;// С��ĳ�������
    public Transform bird;            // С��� Transform
    
    void Start()
    {
        bird.localScale = Vector3.zero;
        clock.OnTheHour.AddListener(OnHourChanged); // ���������¼�
    }

    void OnHourChanged(int hour)
    {
        Debug.Log("Bird aprear��");
        StartCoroutine(AnimateBird());
    }

    IEnumerator AnimateBird()
    {
        
        float elapsedTime = 0f;
        while (elapsedTime <1)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime;
            float curveValue = appearCurve.Evaluate(t); // ��������ֵ
            transform.localScale = Vector2.one * appearCurve.Evaluate(t);
            yield return null;
        }
    }
}

    

