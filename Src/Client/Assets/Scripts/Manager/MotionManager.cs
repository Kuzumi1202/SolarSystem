using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionManager : MonoBehaviour
{
    public DataManager DataManager;

    public List<GameObject> CelestialGO;

    public Dictionary<int, Celestial> CelestialManager = new Dictionary<int, Celestial>();

    public Dictionary<int, Star> StarManager = new Dictionary<int, Star>();
    public Dictionary<int, Planet> PlanetManager = new Dictionary<int, Planet>();
    public Dictionary<int, Satellite> SatelliteManager = new Dictionary<int, Satellite>();

    void Start()
    {
        DataManager.Load();
        // ͬ������
        CelestialManager = DataManager.PlanetManager;

        for (int i = 1; i <= CelestialManager.Count; i++)
        {
            // �����˶����ݳ�ʼ��
            if (CelestialManager[i].Type == CelestialType.SATELLITE)
            {
                SatelliteManager.Add(i, new Satellite(CelestialManager[i]));
                SatelliteManager[i].InitRotationMove(CelestialGO[3], CelestialGO[i - 1]);
            }
            // �����˶����ݵĳ�ʼ��
            else if (CelestialManager[i].Type == CelestialType.PLANET) 
            {
                PlanetManager.Add(i, new Planet(CelestialManager[i]));
                PlanetManager[i].InitRotationMove(CelestialGO[0], CelestialGO[i - 1]);
            }
            // ̫���˶����ݳ�ʼ��
            else StarManager.Add(i, new Star(CelestialManager[i]));
        }
    }


    void Update()
    {
        foreach (int i in StarManager.Keys)
        {
             StarManager[i].AutorotationMove(CelestialGO[i - 1]);
        }

        foreach (int i in SatelliteManager.Keys)
        {
            SatelliteManager[i].RotationMove(CelestialGO[3], CelestialGO[i - 1]);
            SatelliteManager[i].AutorotationMove(CelestialGO[i - 1]);
        }
        foreach (int i in PlanetManager.Keys)
        {
            PlanetManager[i].RotationMove(CelestialGO[0], CelestialGO[i - 1]);
            PlanetManager[i].AutorotationMove(CelestialGO[i - 1]);
        }
    }
}
