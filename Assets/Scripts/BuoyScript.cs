using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuoyScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        gameObject.SetActive(false);
        float x = (float) Random.Range(200, 800);
        float z = (float) Random.Range(200, 800);
        x /= 10;
        z /= 10;
        transform.position = new Vector3(x,26.1f,z);
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate() {
        if(!gameObject.activeSelf){
            
        }
    }
}
