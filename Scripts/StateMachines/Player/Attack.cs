using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Attack 
{
    [field: SerializeField] public string AnimationName { get; private set; }
    [field: SerializeField] public float TransitionDuration { get; private set; } 
    [field: SerializeField] public int ComboStateIndex { get; private set; } = -1; // setting the index to -1 is a little more freeform, it allows us to have combo mixups
    [field: SerializeField] public float ComboAttackTime { get; private set; } // How far through an attack before we can do the next attack, (we are getting closer to animation cancelling)
    [field: SerializeField] public float ForceTime { get; private set; }
    [field: SerializeField] public float Force { get; private set; }
}
