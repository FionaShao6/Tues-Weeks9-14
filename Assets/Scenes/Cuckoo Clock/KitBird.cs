using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class KitBird : MonoBehaviour
{
//{using System.Collections;
//using UnityEngine;

    public KitClock clock;            // 绑定你的 KitClock 组件
    public AnimationCurve appearCurve;// 小鸟的出现曲线
    public Transform bird;            // 小鸟的 Transform
    
    void Start()
    {
        bird.localScale = Vector3.zero;
        clock.OnTheHour.AddListener(OnHourChanged); // 监听闹钟事件
    }

    void OnHourChanged(int hour)
    {
        Debug.Log("Bird aprear！");
        StartCoroutine(AnimateBird());
    }

    IEnumerator AnimateBird()
    {
        
        float elapsedTime = 0f;
        while (elapsedTime <1)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime;
            float curveValue = appearCurve.Evaluate(t); // 计算曲线值
            transform.localScale = Vector2.one * appearCurve.Evaluate(t);
            yield return null;
        }
    }
}

    

