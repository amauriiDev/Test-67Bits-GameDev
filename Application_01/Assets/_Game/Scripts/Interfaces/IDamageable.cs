using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    public void TakeHit(Transform enemy, float force, Transform point){}
}
