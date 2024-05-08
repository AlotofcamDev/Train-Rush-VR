using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentMovement : MonoBehaviour
{
    public List<GameObject> environmentPrefabs = new List<GameObject>();
    public List<GameObject> environmentActives = new List<GameObject>();

    public int environmentCount;
    public int environmentZShift;
    private int tempZShift;

    private Vector3 setEnvironmentPos = Vector3.zero;
    private int maxEnvironmentDist;

    // Start is called before the first frame update
    void Start()
    {
        maxEnvironmentDist = environmentZShift * (environmentCount / 2);

        Debug.Log(maxEnvironmentDist);

        tempZShift = environmentZShift;

        for (int i = 0; i < environmentCount; i++)
        {
            environmentActives.Add(Instantiate(environmentPrefabs[Random.Range(0, environmentPrefabs.Count)]));

            environmentActives[i].transform.position = setEnvironmentPos;
            environmentActives[i].GetComponent<EnvironmentCheckPos>().maxDist = maxEnvironmentDist;

            if (setEnvironmentPos.z >= 0)
            {
                setEnvironmentPos -= new Vector3 (0, 0, tempZShift);
                tempZShift += environmentZShift;
            }
            else
            {
                setEnvironmentPos += new Vector3(0, 0, tempZShift);
                tempZShift += environmentZShift;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
