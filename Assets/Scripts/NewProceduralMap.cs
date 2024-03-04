using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewProceduralMap : MonoBehaviour
{
    
    [SerializeField] int width,height;
    [SerializeField] int minStoneheight, maxStoneheight;
    [SerializeField] GameObject dirt, Grass, rock;


    void Start()
    {
        Generation();
    } //Start

    void Generation()
    {
          for (int x=0; x < width; x++)
          {
           
                int minHeight = height - 1;
                int maxHeight=height +2;
                
                height=Random.Range(minHeight, maxHeight);

                int minStoneSpawnDistance = height- minStoneheight;
                int maxStoneSpawnDistance = height - maxStoneheight;
                int totalStoneSpawnDistance=Random.Range(minStoneSpawnDistance,maxStoneSpawnDistance);

                for (int y = 0; y < height; y++)
                {
                if (y < totalStoneSpawnDistance)
                
                {
                    spawnObj(rock, x, y);
                }else
                 {
                    spawnObj(dirt, x, y);
                 }spawnObj(Grass, x, height);
                }

          }
    } //Generation

    void spawnObj ( GameObject obj, int x, int y)
    {
        obj = Instantiate(obj, new Vector2(x,y), Quaternion.identity);
        obj.transform.parent=this.transform;
    }
}
