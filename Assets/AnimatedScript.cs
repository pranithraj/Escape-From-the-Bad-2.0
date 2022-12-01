using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedScript : MonoBehaviour
{
    public float speedX;
    public float speedY;
    private float currX;
    private float currY;
    // Start is called before the first frame update
    void Start()
    {
        currX = GetComponent<Renderer>().material.mainTextureOffset.x;
        currY = GetComponent<Renderer>().material.mainTextureOffset.y;
    }

    // Update is called once per frame
    void Update()
    {
        currX += Time.deltaTime * speedX;
        currY += Time.deltaTime * speedY;
        GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(currX, currY));
    }
}
