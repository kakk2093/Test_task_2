using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueWall : MonoBehaviour
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
            if (collision.gameObject.GetComponent<Cube>().isBlueCube==true)
            {
                Destroy(collision.gameObject);
                _gameManager.BlueScoreCounter(1);
                _gameManager.TotalScoreCounter(1);

            }
        }
    }
}
