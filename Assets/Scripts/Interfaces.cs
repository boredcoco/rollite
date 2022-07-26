using UnityEngine;
using System.Collections;

//This is a basic interface with a single required
//method.
public interface Health
{
    void loseHealth(float amount);
    bool isActiveShield();
    bool isDashing();
}
