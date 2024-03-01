using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SaberScript : MonoBehaviour
{
    public AudioSource audioSource;
    public float intensity = 0.5f;
    public float duration = 0.3f;
    public XRBaseController controller;

    // Start is called before the first frame update

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {
            audioSource.Play();
            
            controller.SendHapticImpulse(intensity, duration);
        }
    }

}
