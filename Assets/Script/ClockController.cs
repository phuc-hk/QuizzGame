using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockController : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion;
    private float currentTime;

    private void Start()
    {
        currentTime = timeToCompleteQuestion;
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;
    }
}
