/***
 *  Created by: Josh Sutton
 *  Date created: 24 January 2022
 *  
 *  Last edited by: Josh Sutton
 *  Last edited date: 26 January 2022
 *  
 *  Description: spawns multiple cube prefabs into scene.
 * 
 ***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCubes : MonoBehaviour
{
    #region Variables
    /*** VARIABLES***/
    public GameObject cubePrefab; //new GameObject
    public float scalingFactor = 0.95f;
    public int numberOfCubes = 0;
    [HideInInspector]
    public List<GameObject> gameObjectList; //list for cubes
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        gameObjectList = new List<GameObject>(); //instantiates the list

    }//end Start()

    // Update is called once per frame
    void Update()
    {
        numberOfCubes++; //increases the cube counter
        GameObject gObj = Instantiate < GameObject>(cubePrefab);

        gObj.name = "Cube"+numberOfCubes; //names the current cube

        gObj.transform.position = Random.insideUnitSphere; // sets the position to a random point inside a sphere radius of 1

        Color randColor = new Color(Random.value, Random.value, Random.value);
        gObj.GetComponent<Renderer>().material.color = randColor; //sets the material to a random color

        gameObjectList.Add(gObj); //adds game object into the list

        List<GameObject> removeList = new List<GameObject>(); //creates a list for objects that need to be removed

        foreach (GameObject goTemp in gameObjectList)
        {
            float scale = goTemp.transform.localScale.x;
            scale = scale * scalingFactor;
            goTemp.transform.localScale = Vector3.one * scale;
            if (scale <= 0.1f)
            {
                removeList.Add(goTemp);
            }//end if(scale <= 0.1f)

        }//end foreach in GameObjectList

        foreach (GameObject goTemp in removeList)
        {
            gameObjectList.Remove(goTemp); //removes from gameObjectList
            Destroy(goTemp); //destroys gameObject from scene
            numberOfCubes--;
        }

    }//end Update()
}
