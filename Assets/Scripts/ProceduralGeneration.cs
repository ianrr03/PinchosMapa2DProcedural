using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Procedural : MonoBehaviour
{

    [SerializeField] int widht; //Anchura
    [SerializeField] int height; //altura
    [SerializeField] GameObject dirt;
    [SerializeField] GameObject Grass;
    [SerializeField] GameObject rock;
    [SerializeField] int minRockDistance;
    [SerializeField] int maxRockDistance;


    // Start is called before the first frame update
    void Start()
    {
        Generation();
    }

    private void Generation()
    {
        for (int x = 0; x < widht; x++)
        {
            //Vamos a modificar la altura, pero de manera gradual y creamos una minima altura y una maxima
            int minHeight = height - 1;
            int maxHeight = height + 2;

            height = Random.Range(minHeight, maxHeight); //Calculamos la altura

            //Distancia de la altura de la piedra
            int minRockSpawnDistance = height - minRockDistance;
            int maxRockSpawnDistance = height - maxRockDistance;
            int totalRockSpawnDistance =Random.Range(minRockSpawnDistance, maxRockSpawnDistance);

            for (int y = 0; y < height; y++)
                if(y<totalRockSpawnDistance)
                {
                    spawnObj(rock, x, y);
                }
                else
                {
                    spawnObj(dirt, x, y); 
                }

            if(totalRockSpawnDistance== height)
            {
                spawnObj(rock, x, height);
            }
            else
            {
                spawnObj(Grass, x, height - 0.6f);
            }

            


        }//for
    }//Generation

    /// <summary>
    /// 
    //////// Spawn object => expandir
    /// 

    void spawnObj(GameObject obj, int x, float y)
    {
        obj= Instantiate(obj, new Vector2(x,y), Quaternion.identity);
        obj.transform.parent = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    } //Update
}
