using System.Collections;
using UnityEngine;

public class ConveyorScript : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] public float spawnRate;
    public Box[] boxs;

    protected bool canSpawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        {
            StartCoroutine(Spawn());
        }
    }
    protected IEnumerator Spawn()
    {
        //Debug.Log("Fire");
        canSpawn = false;
        SpawnBox();
        yield return new WaitForSeconds(spawnRate);
        canSpawn = true;
    }
    void SpawnBox()
    {
        Box box = Instantiate(boxs[Random.Range(0, boxs.Length)], spawnPoint.position, new Quaternion(0,0,0,0));
//        Debug.Log(box.name);
    }
}
