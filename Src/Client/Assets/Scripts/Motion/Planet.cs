using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : Celestial
{
    float angle = 0.0f;
    Vector3 direction;

    public Planet(Celestial celestial)
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

    public new void InitRotationMove(GameObject master, GameObject Celestial)
    {
        this.direction = Celestial.transform.position - master.transform.position;
        this.angle = Mathf.Atan2(direction.z, direction.x);
    }
    public new void RotationMove(GameObject master,GameObject Celestial)
    {
        this.angle += this.Revolution * Time.deltaTime;
        float x = master.transform.position.x + this.direction.magnitude * Mathf.Cos(angle);
        float z = master.transform.position.z + this.direction.magnitude * Mathf.Sin(angle);
        Celestial.transform.position = new Vector3(x, 0, z);
    }

    public new void AutorotationMove(GameObject Celestial)
    {
        Celestial.transform.Rotate(Vector3.up * this.Autorotation * Time.deltaTime);
    }
}
