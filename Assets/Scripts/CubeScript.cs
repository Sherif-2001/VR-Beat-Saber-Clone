using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    public float moveSpeed = 4f;
    private Transform cubePos;
    // Start is called before the first frame update
    void Start()
    {
        cubePos = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        cubePos.position += Vector3.back * moveSpeed * Time.deltaTime;
        if (cubePos.position.z <= -10f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Saber"))
        {
            Destroy(this.gameObject);
            ScoreManager.instance.addPoint();
        }
    }
}
