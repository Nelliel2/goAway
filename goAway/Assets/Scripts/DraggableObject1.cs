using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DraggableObject1 : MonoBehaviour
{
    private Rigidbody _rb;
    private Vector3 _initialScale;
    [SerializeField] private Vector3 _targetPossition;
    [SerializeField] private bool _follow;
    [SerializeField] private float _dragSpeed = 10f;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public virtual void FixedUpdate()
    {
        if (!_follow)
            return;
        Vector3 moveDir = _targetPossition - _rb.position;
        _rb.velocity = moveDir * _dragSpeed;
    }

    public void StartFollingObj()
    {
        _follow = true;
    }

    public void SetTargetPossition (Vector3 newTargetPossition)
    {
        _targetPossition = newTargetPossition;
    }

    public void StopFolloingObj()
    {
        _follow = false;
        _rb.velocity = Vector3.zero;
    }
}
