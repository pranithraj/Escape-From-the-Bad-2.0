/**
 * Author: Pranith Raj Jajala
 **/
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    public Text health;
    public void UpdateLifeBanner(float points)
    {
        this.health.text = "Life: " + points;
    }
}
