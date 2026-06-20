using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    Transform _player;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private Release _release;
    public void Forward()
    {
        _player.position += Vector3.back * _speed;
    }

    public void ReverseForward()
    {
        _player.position = new Vector3(_player.position.x, _player.position.y, _player.position.z);
    }

    public void Left()
    {
        _player.position += Vector3.right * _speed;
    }

    public void ReverseLeft()
    {
        _player.position = new Vector3(_player.position.x, _player.position.y, _player.position.z);
    }

    public void Right()
    {
        _player.position += Vector3.left * _speed;
    }

    public void ReverseRight()
    {
        _player.position = new Vector3(_player.position.x, _player.position.y, _player.position.z);
    }

    public void Back()
    {
        _player.position += Vector3.forward * _speed;
    }

    public void ReverseBack()
    {
        _player.position = new Vector3(_player.position.x, _player.position.y, _player.position.z);
    }

        private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        _release.CanClick = true;
    }
}