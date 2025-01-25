using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public FaceManager facePrefab;
    private FaceManager _face;
    private void Start()
    {
        _face = Instantiate(facePrefab);
        _face.target = this.transform;
    }
    
}
