using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    [SerializeField] private float _speedCar = 10f;
    [SerializeField] private float _speedgain = 0.2f;
    [SerializeField] private float _speedSteer = 200f;

    private int _steerValue;
    void Update()
    {
        _speedCar += _speedgain * Time.deltaTime;
        transform.Rotate(0f, _steerValue * Time.deltaTime * _speedSteer, 0f);
        transform.Translate(Vector3.forward * _speedCar * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene(0);
        }
    }
    public void Steering(int Value)
    {
        _steerValue = Value;
    }
}
