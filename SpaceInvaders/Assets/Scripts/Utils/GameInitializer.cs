using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    public GameObject spaceCell;
    public GameObject cityCell;
    public GameObject bgCell;
    public GameObject bunker;
    public GameObject[] enemiesObj;
    private static GameInitializer m_instance;
    public static GameInitializer Instance { get { return m_instance; }}

    void Awake()
    {
        if(m_instance != null && m_instance != this)
        {
            Destroy(this);
        }
        else
        {
            m_instance = this;
        }
    }
    
    public void CreateSpaceCells(MyGrid grid)
    {
        for(int i = 0; i < grid.rows; i++)
        {
            for(int j = 0; j < grid.columns; j++)
            {
                Cell cell = grid.CellAt(i, j);
                ContainersManager.Instance.InstantiateWorldCell(spaceCell, new Vector2(cell.column, cell.row));
            }
        }
    }

    public void CreateCityCells(MyGrid grid)
    {
        for(int j = 0; j < grid.columns; j += 4)
        {
            Cell cell = grid.CellAt(8, j);
            ContainersManager.Instance.InstantiateWorldCell(cityCell, new Vector2(cell.column + 1.5f, cell.row));
        }
    }

    public void CreateBakcgroundCells(MyGrid grid)
    {
        for(int i = 0; i < 7; i++)
        {
            for(int j = 0; j < grid.columns; j++)
            {
                Cell cell = grid.CellAt(i, j);
                float x = cell.column;
                float y = cell.row;
                if(i == 6)
                {
                    y -= 0.5f;
                }
                ContainersManager.Instance.InstantiateWorldCell(bgCell, new Vector2(x, y));
            }
        }
    }

    public void CreateBunkers()
    {
        for(int i = 2, j = 0; j < 4; i += 5, j++)
        {
            ContainersManager.Instance.InstantiateBunker(bunker, new Vector2(i, 4));
        }
    }

    public void CreateEnemies(MyGrid grid)
    {
        int rowCount = 0;
        for(int i = 13; i < 18; i++)
        {
            for(int j = 3; j < grid.columns - 3; j++)
            {
                Cell cell = grid.CellAt(i, j);
                ContainersManager.Instance.InstantiateEnemy(enemiesObj[rowCount],
                                            new Vector2(cell.column, cell.row))
                                            .GetComponent<Enemy>().Initialize();
            }
            rowCount++;
        }
    }
}
