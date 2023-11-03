using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockUI : MonoBehaviour
{
    [SerializeField] Image clockImage;
    [SerializeField] ClockController clockController;
   

    private void Start()
    {
        clockImage = GetComponent<Image>();
    }

    private void Update()
    {
        clockImage.fillAmount = clockController.GetTimerPercentage();
    }
}
