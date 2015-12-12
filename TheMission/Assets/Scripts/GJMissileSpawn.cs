using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;
namespace Assets { 

    public class GJMissileSpawn : MonoBehaviour {

        public GameObject missilePrefab;

	    // Use this for initialization
        void Start()
        {
        }


        // Update is called once per frame
	    void Update () 
        {
	        if (Input.GetMouseButtonDown(0))
            {
                
                Vector3 earthPosition = this.transform.parent.localPosition;
                Debug.Log(earthPosition);
                var newMissile = (GameObject)Instantiate(missilePrefab, new Vector3(earthPosition.x, earthPosition.y, earthPosition.z), Quaternion.identity);
            }
	    }

        void SpawnAsteroid()
        {
        
        }
    }
}
