using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRayCast : MonoBehaviour
{


    [SerializeField] private Camera _mainCamera;
    [SerializeField] private float _rayCastDistanse = 8f;
    [SerializeField] private LayerMask _raycastLayerMask;

    private DraggableObject1 _currentlydragObject = null;
    [SerializeField] private float _dragDistance = 0.5f;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            RaycastHit hit;

            if (Physics.Raycast(_mainCamera.transform.position, _mainCamera.transform.forward, out hit, _rayCastDistanse, _raycastLayerMask))
            {
                /*if (hit.collider.TryGetComponent(out Door1 door))
                {
                    door.OpenOrClose();

                    Debug.Log("we hit door");
                }
                if (hit.collider.TryGetComponent(out OpenCase casebox))
                {
                    casebox.OpenOrClose();

                    Debug.Log("we hit case");
                }
*/
                if (hit.collider.TryGetComponent(out OpenebleObjects _openable))
                {
                    _openable.OpenOrClose();

                    Debug.Log("we hit ");
                }


                /*else
                    return;*/

            }

        }



        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;

            if (Physics.Raycast(_mainCamera.transform.position, _mainCamera.transform.forward, out hit, _rayCastDistanse, LayerMask.GetMask("Touch")))
            {

                if (hit.collider.TryGetComponent(out OpenebleObjects _openable))
                {
                    Debug.Log("we open");
                    _openable.OpenOrClose();
                    FindObjectOfType<MySceneManager>().LoadNewScene(0);
                }
          
            }
        }





        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(_mainCamera.transform.position, _mainCamera.transform.forward, out hit, _rayCastDistanse, LayerMask.GetMask("Draggable")))
            {
                if (hit.collider.TryGetComponent(out DraggableObject1 _dragObj))
                {
                    _dragObj.StartFollingObj();
                    _currentlydragObject = _dragObj;
                    Debug.Log("we hit ang drag");
                }

            }
        }



        if (_currentlydragObject != null)
        {
            Vector3 targetPossition = _mainCamera.transform.position + _mainCamera.transform.forward * _dragDistance;
            _currentlydragObject.SetTargetPossition(targetPossition);

            Debug.Log("we hit ang drag drag drag");
        }

        if (Input.GetMouseButtonUp(0))
         {
            if (_currentlydragObject != null)
            {
               _currentlydragObject.StopFolloingObj();
               _currentlydragObject = null;

                Debug.Log("we hit and put");
            }
        }

        Debug.DrawLine(_mainCamera.transform.position, _mainCamera.transform.forward * _rayCastDistanse, Color.yellow);

    }
}


    
