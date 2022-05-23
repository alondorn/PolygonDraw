using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlonDorn
{
    public interface IPlacable
    {
        GameObject PlaceInScene(Vector3 position, bool isLocalSpace = false);
    }
}
