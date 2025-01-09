using System;
using System.Collections.Generic;
using UnityEngine;

public class AccelerationController : MonoBehaviour
{
    [SerializeField] Animator _animator;
    private int counter;
    private DateTime _startDate;
    private DateTime _secondDate;

    private void Start()
    {
        counter = 0;
    }

    public void TapToIncreasePlayerSpeed()
    {
        if (counter == 0)
        {
            _startDate = DateTime.Now;
            counter++;
        }
        else
        {
            _secondDate = DateTime.Now;
            if (_secondDate.Second - _startDate.Second < 1f)
            {
                counter++;
            }
            else
            {
                _startDate = DateTime.Now;
            }
        }
    }

    /*private IEnumerator HurryUpPlayer()
    {
        _animator.speed = 1.5f;
        yield return new WaitForSeconds(1);
    }*/
}
