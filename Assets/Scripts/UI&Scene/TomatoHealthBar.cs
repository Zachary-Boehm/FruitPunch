using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TomatoHealthBar : MonoBehaviour
{
    private Slider Health;
    private void Awake() {
      Health = GetComponent<Slider>();
    }
    public void updateHealthImage(){
      if(Health.value < (.5*Health.maxValue)){ //50% of health left
        //Switch image
      }
    }
}
