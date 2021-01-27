using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hielo : MonoBehaviour
{
    public int myLayer = 11; // define the layer in the prefab script (8 to 31)
    // Start is called before the first frame update
    void Start()
    {
     gameObject.layer = myLayer; // move the object to its layer...
     // and ignore collisions between objects in it:
     Physics.IgnoreLayerCollision(myLayer, myLayer, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
