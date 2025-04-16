public enum CelestialType
{
    STAR,
    PLANET,
    SATELLITE
}

public enum CelestialClass
{
    SUN,
    MERCURY,
    VENUS,
    EARTH,
    MOON,
    MARS,
    JUPITER,
    SATURN,
    URANUS,
    NEPTUNE
}
public class Celestial
{
    public int TID { get; set; }

    public string Name { get; set; }

    public CelestialType Type { get; set; }

    public CelestialClass Class { get; set; }

    public string Master { get; set; }

    public float Autorotation { get; set; }

    public float Revolution { get; set; }

    public string Description { get; set; }

    public interface InitRotationMove { }
    public interface RotationMove { }
    public interface AutorotationMove { }
}
