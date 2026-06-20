using System;
using Unity.Mathematics;
using UnityEngine;

public class Release : MonoBehaviour
{
    [SerializeField]
    private GameObject _ballBase;
    [SerializeField]
    private float _force = 500;
    public bool CanClick = true;
    
    public void ReleaseBall()
    {
        if(!CanClick) return;

        CanClick = false;

        GameObject ball = Instantiate(_ballBase, this.transform.position + new Vector3(0,0, 3), quaternion.identity);
        if(ball.TryGetComponent(out Rigidbody rb))
        {
            float randomX = UnityEngine.Random.Range(0, 0.5f);
            float randomY = UnityEngine.Random.Range(0, 2f);
            rb.AddForce(new Vector3(0, randomY, 1) * _force, ForceMode.Impulse);
        }
    }
}
