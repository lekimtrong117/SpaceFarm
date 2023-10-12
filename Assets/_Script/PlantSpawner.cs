using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSpawner : MonoBehaviour
{
    [SerializeField] public int horizontal_num;
    [SerializeField] public int vertical_num;
    [SerializeField] public float horizontal_dis;
    [SerializeField] public float vertical_dis; 
    Transform plant;
    Transform trans;

    private void Awake()
    {
        trans = transform;
    }
    private void Start()
    {
        CreateFarm();
    }
    private void CreateFarm()
    {

        for (int i = 0; i < horizontal_num; i++)
            for (int j = 0; j < vertical_num; j++)
            {
                if (j % 2 == 1)
                    plant = PoolManager.Instance.Spawn("Plant1");
                else plant = PoolManager.Instance.Spawn("Plant2");
                plant.transform.position= trans.position+ new Vector3(i*horizontal_dis,0,j*vertical_dis);
                plant.SetParent(trans);
                plant.gameObject.GetComponent<PlantControl>().isWatered = false;
                //
                LevelManager.Instance.totalPlant++;
            }    
    }    
}
