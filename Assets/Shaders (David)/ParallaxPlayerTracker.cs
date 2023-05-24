using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxPlayerTracker : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sr.material.SetTextureOffset("_PlayerPosition", Camera.main.transform.position);
    }
}
