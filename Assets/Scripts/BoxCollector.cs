using Unity.Mathematics;
using UnityEngine;

public class BoxCollector : MonoBehaviour
{
    [SerializeField]private Transform reSpawnPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision coll)
    {
        //Debug.Log(coll.gameObject.name);
        if (coll.gameObject.CompareTag("Box"))
        {
            GameObject box = Instantiate(coll.gameObject , reSpawnPoint.position, quaternion.identity);
            Destroy(coll.gameObject);
            GameManager.boxCount++;
           
            Destroy(box, 4);
        }
    }
}
