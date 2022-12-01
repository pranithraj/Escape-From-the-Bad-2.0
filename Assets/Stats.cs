/**
 * Author: Pranith Raj Jajala
 **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float health;

    public void UpdateLife (float score)
    {
        health = health - score;
    }
}
