using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplatterEnd : MonoBehaviour
{
    
    public void endSplatter(string variable)
    {
        GetComponent<Animator>().SetBool(variable, false);
        GetComponent<SpriteRenderer>().sprite = null;
    }
}
