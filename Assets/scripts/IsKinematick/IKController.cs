using UnityEngine;
using System.Collections;
public delegate void Call();

public class IKController : MonoBehaviour {
    public Animator animator;
    IKObject _ikObject;
    public IKObject ikObject
    {
        get { return _ikObject; }
    }
    Call _callBack;
    bool _isActive = false;
    float _currentWeight = 0f;
    // Активирует IK

    public void activate(Call callBack, IKObject ikObject)
    {
        _callBack = callBack;
        _ikObject = ikObject;
        _isActive = true;
        StartCoroutine(upWeight());
    }

    // Зеркало для unactivate( bool fastActivate) чтоб каждый раз false и null не писать

    public void unactivate()
    {
        unactivate(false, null);
    }
    //Деактивируем IK

    public void unactivate(bool isFast, Call callBack)
    {
        if (isFast)
        {
            _isActive = false;
            _ikObject = null;
            _currentWeight = 0;
            if (_callBack != null) _callBack();
            _callBack = null;
        }
        else
        {
            _callBack = callBack;
            StartCoroutine(downWeight());
        }
    }

            IEnumerator downWeight()
            {
                for (float i = 1; i > 0f; i -= Time.deltaTime)
                {
                    _currentWeight = i;
                    yield return null;
                }
                _isActive = false;
                _ikObject = null;
                _currentWeight = 0;
                if (_callBack != null) _callBack();
                _callBack = null;
            }
            //Повышение веса
            IEnumerator upWeight()
            {
                for (float i = 1; i > 0f; i += Time.deltaTime)
                {
                    _currentWeight = i;
                    yield return null;
                }
                if (_callBack != null) _callBack();
                _callBack = null;
            }
        
        void OnAnimatorIK()
{
            if (_isActive)
            {
                if (_ikObject == null)
                {
                    _isActive = false;
                    _callBack = null;
                    _ikObject = null;
                    _currentWeight = 0;
                }
                else
                {
                    if (_ikObject.nodes != null)
                    {
                        for (int i = 0; i < _ikObject.nodes.Length; i++)
                        {
                            animator.SetIKPositionWeight(_ikObject.nodes[i].goal, _currentWeight);
                            animator.SetIKRotationWeight(_ikObject.nodes[i].goal, _currentWeight);
                            animator.SetIKPosition(_ikObject.nodes[i].goal, _ikObject.transform.TransformPoint(_ikObject.nodes[i].position));
                            animator.SetIKRotation(_ikObject.nodes[i].goal, _ikObject.transform.rotation * Quaternion.Euler(_ikObject.nodes[i].position));
                        }
                    }
                    if (_ikObject.hints != null)
                    {
                    for (int i = 0; i < _ikObject.hints.Length; i++)
                    {
                        animator.SetIKHintPositionWeight(_ikObject.hints[i].hint, _currentWeight);
                        animator.SetIKHintPositionWeight(_ikObject.hints[i].hint, 0f); // исправить потом _ikObject.transform.TransformPoint(_ikObject.nodes[i].position))
                    }
                    }
                }
            }
        }
    }

