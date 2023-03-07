
namespace VRHackathon.Core
{
    public class PlantGoal : Quest.QuestGoal
    {
        public string plant;

        public override string GetDescription()
        {
            return $"Plant the {plant}";
        }


        public override void Initialize()
        {
            base.Initialize();
            EventManager.Instance.AddListener<PlantGameEvent>(OnPlanting);
        }
        private void OnPlanting(PlantGameEvent eventInfo)
        {
            if (eventInfo.plantName == plant)
            {
                currentAmount++;
                Evaluate();
            }
        }

    }
}
