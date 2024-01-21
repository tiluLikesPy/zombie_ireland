using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class amoTransparent : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
