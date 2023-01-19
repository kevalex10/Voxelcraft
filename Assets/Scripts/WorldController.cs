using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    public GameObject Block;
    public int Width = 1;
    public int Height = 1;
    public int Depth = 1;

    private void Start()
    {
        StartCoroutine(BuildWorld());
    }

    public IEnumerator BuildWorld()
    {
        for(int z = 0; z < Depth; z++)
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    // 50% chance to skip a block on the top two layer.
                    if ((y >= Height - 2) && Random.Range(0, 100) < 50)
                    {
                        continue;
                    }

                    Vector3 pos = new Vector3(x, y, z);
                    GameObject cube = GameObject.Instantiate(Block, pos, Quaternion.identity);
                    cube.name = $"{x}_{y}_{z}";
                    cube.GetComponent<Renderer>().material = new Material(Shader.Find("Standard"));
                }

                yield return null;
            }
        }
    }
}
