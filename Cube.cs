using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public bool isInteractable=true;
    public bool isRadCube, isBlueCube;

    [SerializeField] private float _notInterectibleTime=0.3f;

    private float _startNotInterectibleTime;

    private void Start()
    {
        _startNotInterectibleTime = _notInterectibleTime;
    }

    private void Update()
    {
        _startNotInterectibleTime -= Time.deltaTime;

        if (_startNotInterectibleTime <= 0)
        {
            isInteractable = true;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("Walls"))
        {
            isInteractable = false;
            _startNotInterectibleTime = _notInterectibleTime;
        }
        
    }
}
