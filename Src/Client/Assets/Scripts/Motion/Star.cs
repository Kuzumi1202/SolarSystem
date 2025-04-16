using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : Celestial
{
    public Star(Celestial celestial)
    {
        this.TID = celestial.TID;
        this.Name = celestial.Name;
        this.Type = celestial.Type;
        this.Class = celestial.Class;
        this.Master = celestial.Master;
        this.Autorotation = celestial.Autorotation;
        this.Revolution = celestial.Revolution;
        this.Description = celestial.Description;
    }


    public new void AutorotationMove(GameObject Celestial)
    {
        Celestial.transform.Rotate(Vector3.up * this.Autorotation * Time.deltaTime);
    }
}
