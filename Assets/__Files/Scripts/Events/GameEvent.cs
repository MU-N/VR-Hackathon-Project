

public abstract class GameEvent
{
    public string EventDesaription;

}

public class PlantGameEvent : GameEvent
{
    public string plantName;
    public PlantGameEvent(string name)
    {
        plantName = name;

    }
}

