using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public List<GameObject> spawners;
    public List<GameObject> cubes;
    public List<Material> cubeMaterials;
    private float timer = 0;
    public float maxTimer = 4f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= maxTimer)
        {
            int randomCube = Random.Range(0, cubes.Count);
            int randomSpawner = Random.Range(0, spawners.Count);
            int randomMaterial = Random.Range(0, cubeMaterials.Count);
            GameObject currentCube = Instantiate<GameObject>(cubes[randomCube], spawners[randomSpawner].transform.position, Quaternion.identity);
            currentCube.GetComponent<MeshRenderer>().material = cubeMaterials[randomMaterial];
            timer = 0;
        }
    }
}
