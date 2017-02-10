using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


    class ObstacleDestroyer : MonoBehaviour
    {


        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.tag == "Ball") {
			ScoreManager.currentballs--;
			//free up some memory
			Destroy (col.gameObject);

		   }
		    
        }
    }

