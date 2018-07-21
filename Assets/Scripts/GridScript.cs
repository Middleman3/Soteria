using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScript : MonoBehaviour {

    public GameObject gridItem;
    public int NumberOfColumns = 10; // number of columns for the grid
    public int NumberOfRows = 10; // number of rows for the grid
    public float SeperationValueX = 0.0f; // Distance between each column
    public float SeperationValueZ = 0.0f; // Distance between each Row

    private float tempSepX = 0; // used to calculate the separation between each column
    private float tempSepZ = 0;// used to calculate the separation between each row

	void Start () {
        CreateGrid();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void CreateGrid()
    {
        for (int i = 0; i < NumberOfColumns; i++)
        {//loop 1 to loop through columns
            for (int j = 0; j < NumberOfRows; j++)
            {//loop 2 to loop through rows
                Instantiate(gridItem, new Vector3(i + tempSepX, 0, j + tempSepZ), Quaternion.identity);
                tempSepZ += SeperationValueZ;//change the value of seperation between rows
            }
            tempSepX += SeperationValueX;//change the value of seperation between columns
            tempSepZ = 0;//Reset the value of the seperation between the rows so it won‘t cumulate
        }
    }
}
