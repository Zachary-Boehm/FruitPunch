using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TomatoHealthBar : MonoBehaviour
{
    [SerializeField]private Slider Health;
    [SerializeField]private Image TomatoState;
    [SerializeField]private Sprite[] TomatoStates;
    [SerializeField] private TextMeshProUGUI healthNumber;
    private float good,damaged;
    private void Start() 
    {
      good = .5f * Health.maxValue;
      damaged = .15f * Health.maxValue;
      healthNumber.text = Health.value.ToString();
    }
    public void updateHealthImage()
    {
        if(Health != null)
        {
            if(Health.value > good){ //50% of health left
                TomatoState.sprite = TomatoStates[0];
            }
            else if(Health.value <= good && Health.value > damaged)
            {
                TomatoState.sprite = TomatoStates[2];
            }
            else if(Health.value <= damaged)
            {
                TomatoState.sprite = TomatoStates[1];
            }
        }
    }

    public void updateHealthNumber()
    {
        healthNumber.text = Health.value.ToString();
    }
}
