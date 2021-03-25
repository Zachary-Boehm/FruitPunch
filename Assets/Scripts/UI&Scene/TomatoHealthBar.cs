using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TomatoHealthBar : MonoBehaviour
{
    private Slider Health;
    [SerializeField]private Image TomatoState;
    [SerializeField]private Sprite[] TomatoStates;
    private float good,damaged;
    private void Start() {
      Health = GetComponent<Slider>();
      good = .5f * Health.maxValue;
      damaged = .15f * Health.maxValue;
      Debug.Log(good);
      Debug.Log(damaged);
    }
    public void updateHealthImage()
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
