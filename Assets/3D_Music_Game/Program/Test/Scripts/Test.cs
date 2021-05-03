using UnityEngine;
using System;
using UniRx;
using UniRx.Triggers;

public class Test : MonoBehaviour
{
    [SerializeField] private float intervalTime = 0.25f;

    private void Start()
    {
        this.UpdateAsObservable()
            .Where(_ => Input.GetKey(KeyCode.Return))
            .ThrottleFirst(TimeSpan.FromSeconds(intervalTime))
            .Subscribe(_ => Attack());
    }

    void Attack()
    {
        Debug.Log("Attack");
    }
}