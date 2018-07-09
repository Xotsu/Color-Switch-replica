using UnityEngine;
public class Spawn : MonoBehaviour {

    public GameObject[] obj;

    //public float SpawnMin = 1f;

	// Use this for initialization
	void Start () {
        SpawnObject();
	}
	void SpawnObject()
    {

        Instantiate(obj[Random.Range(0, obj.GetLength(0))], transform.position, Quaternion.identity);
        //Invoke("Spawn", Random.Range(SpawnMin, SpawnMax));
    }
}
