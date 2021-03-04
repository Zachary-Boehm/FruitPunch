using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DamageType : MonoBehaviour
{
  
}

public enum DamageAffect{
  Slow = 1, //Will slow target
  Stun = 2, //Will stun target
  Bleed = 3, //Will apply bleed affect to the target
  Other = 0//Default state
}

