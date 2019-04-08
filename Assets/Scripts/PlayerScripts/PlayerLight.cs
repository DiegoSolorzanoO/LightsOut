using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLight : MonoBehaviour
{

    private new Light light;
    private Coroutine flickering;


    private void Awake() {
        light = GetComponentInChildren<Light>();
    }

    public void StartFlicker() {
        flickering = StartCoroutine(Flickering());
    }

    public void StopFlicker() {
        StopCoroutine(Flickering());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Flickering() {
            while (true) {
                light.range = Random.Range(300, 400);
                yield return new WaitForSeconds(0.1f);
            }
    }
}
