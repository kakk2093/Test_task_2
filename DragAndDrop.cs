using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{

    [SerializeField] private float _dragSpeed;
    [SerializeField] private LayerMask _whatClikable;

    private Camera _camera;

    // Start is called before the first frame update
    void Start()
    {
        _camera = FindObjectOfType<Camera>().GetComponent<Camera>();
    }

  

    private void FixedUpdate()
    {
        DragObject();

       
    }

    private void DragObject()
    {

        if (Input.GetMouseButton(0))
        {

            Ray _ray = _camera.ScreenPointToRay(Input.mousePosition);

            RaycastHit _hitInfo;

            if (Physics.Raycast(_ray, out _hitInfo, 100, _whatClikable))
            {
              
                

            
                if(_hitInfo.collider != null)
                {
                    if (_hitInfo.collider.gameObject.CompareTag("Cube") )
                    {
                        if (_hitInfo.collider.gameObject.GetComponent<Cube>().isInteractable == true)
                        {
                            float _initialDistance = Vector3.Distance(_hitInfo.collider.gameObject.transform.position, _camera.transform.position);
                            Vector3 _direction = _ray.GetPoint(_initialDistance) - _hitInfo.collider.gameObject.transform.position;

                            _hitInfo.collider.gameObject.GetComponent<Rigidbody>().velocity = _direction * _dragSpeed;

                        }
                      
                    }
                }


              
            }


        }
    }

}
