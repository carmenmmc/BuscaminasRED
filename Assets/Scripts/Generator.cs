using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject piece;
    public int width, height;
    public int bombsNumber;
    private GameObject[][] map;
    public static Generator gen;

    private void Start()
    {
        CreateMap();
        FixCamera();
        SetBombs();
        gen = this;
    }

    void CreateMap()
    {
        map = new GameObject[width][];
        for ( int i = 0; i < width; i++)
        {
            map[i] = new GameObject[height];
            for( int j = 0; j < height; j++)
            {
                map[i][j] = Instantiate(piece, new Vector2(i, j),Quaternion.identity);
                map[i][j].GetComponent<Piece>().x = i;
                map[i][j].GetComponent<Piece>().y = i;
            }
        }
    }
    void FixCamera()
    {
        Camera.main.transform.position = new Vector3((float)width / 2-0.5f, (float)height / 2-0.5f, -10);
    }

    void SetBombs()
    {
      
        int cont = 0;
        while (cont < bombsNumber)
        {
            int x = Random.Range(0, width);
            int y = Random.Range(0, height);
            if (!map[x][y].GetComponent<Piece>().bomb)
            {
                cont++;
                map[x][y].GetComponent<Piece>().bomb = true;
            }
        }
    }

    public int GetBombs(int x, int y)
    {
        int cont = 0;
        if(x > 0 && y < height - 1 && map[x - 1][y + 1].GetComponent<Piece>().bomb)
            cont++;
        if (y < height - 1 && map[x][y + 1].GetComponent<Piece>().bomb)
            cont++;
        if (x < width - 1 && y < height - 1 && map[x + 1][y + 1].GetComponent<Piece>().bomb)
            cont++;
        if (x > 0 && map[x - 1][y].GetComponent<Piece>().bomb)
            cont++;
        if (x < width - 1 && map[x + 1][y].GetComponent<Piece>().bomb)
            cont++;
        if (x > 0 && y > 0 && map[x - 1][y - 1].GetComponent<Piece>().bomb)
            cont++;
        if (y > 0 && map[x][y - 1].GetComponent<Piece>().bomb)
            cont++;
        if (x < width - 1 && y > 0 && map[x + 1][y - 1].GetComponent<Piece>().bomb)
            cont++;

        return cont;
    }
}

