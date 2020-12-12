using UnityEngine;
using UnityEngine.Animations.Rigging;

public class UnitychanWalk : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Rig _spineRig;
    private Animator _animator;
    private bool _isFind;
    private bool _isArrive;
    private float _moveSpeed = 1f;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        Invoke("TargetFind", 7f);   
    }

    private void OnAnimatorMove()
    {
        if (_isFind)
        {
            transform.LookAt(_target);
        }
        if (!_isArrive)
        {
            transform.position += transform.forward * _moveSpeed * Time.deltaTime;
        }
    }

    private void TargetFind()
    {
        _isFind = true;
        _spineRig.weight = 0;
        _moveSpeed = 3f;
        _animator.SetBool("isFind", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            _isArrive = true;
            _animator.SetBool("isArrive", true);
        }
    }
}
