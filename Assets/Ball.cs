using System;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private Transform _ballTransform;
    private Vector3 _endPosition;
    // 質量
    private float _mass = 50f;
    private Vector3 _addVelocity;
    private float angle; // random
    // 半径
    private float _radious;
    // 空気抵抗係数
    private float _resistanceCoefficient = 0.354f;
    // 空気の密度
    private float _airDensity = 1.2f;
    // 投影面積
    private float _projectedArea;
    // 重力
    private const float _gravity = -9.81f;

    void Start()
    {
        _projectedArea = MathF.PI * _radious * _radious;

        Init();
    }

    private void Init()
    {
        angle = UnityEngine.Random.Range(15f, 60f);
        float rad = angle * Mathf.Deg2Rad;
        Simulate(10, rad);
    }

    public Vector3 SetVelocity(float initailSpeed, float rad)
    {
        Vector3 velocity = Vector3.one;

        float y = velocity.y * MathF.Sin(rad) * initailSpeed;
        float x = velocity.x * MathF.Cos(rad) * initailSpeed;

        return new Vector3(x, y, 0);
    }

    void Simulate(float initailSpeed, float rad)
    {
        Vector3 pos = _ballTransform.position;
        Vector3 velocity = SetVelocity(initailSpeed, rad);
        float dt = 0.01f;

        Debug.Log(velocity);

        for(int i = 0; i < 10000; i++)
        {
            // 空気抵抗
            Vector3 air = -velocity.normalized * (
                _airDensity / 2 *
                _resistanceCoefficient *
                _projectedArea * 
                velocity.sqrMagnitude
            );

            Vector3 gravityForce = Vector3.down * _mass * _gravity;
            Vector3 totalForce = air + gravityForce;

            Vector3 accel = totalForce / _mass;

            velocity += accel * dt;
            pos += velocity * dt;

            if(pos.y <= 0) break;
        }

            // シュミレーション終わらせる
            Debug.Log(pos);

            Debug.Log("終わった");
    }
}
