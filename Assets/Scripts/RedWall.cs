using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedWall : MonoBehaviour
{

    private GameManager _gameManager;


    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube"))
        {
            if (collision.gameObject.GetComponent<Cube>().isRadCube == true)
            {
                Destroy(collision.gameObject);
                _gameManager.RedScoreCounter(1);
                _gameManager.TotalScoreCounter(1);

            }
        }
    }
}
