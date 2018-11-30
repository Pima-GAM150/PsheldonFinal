using System.Collections;
using UnityEngine;

public class Unit : MonoBehaviour{

    public RuleTile rt { get; protected set; }

    public void Place(RuleTile target)
    {
        //make sure old tile location is not still pointing to this object.
        if (rt != null && rt.content == gameObject)
            rt.content = null;

        //link unit and tile references.
        rt = target;

        if (target != null)
            target.content = gameObject;
    }

    public void Match()
    {
        transform.localPosition = rt.center;
    }

}
