using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace VRHackathon.Core
{
    [System.Serializable]
    public class Quest : ScriptableObject
    {
        public bool completed { get; protected set; }
        public QuestCompletedEvent questCompleted;

        public struct Info
        {
            public int id;
            public string title;
            public string description;
            public Sprite icon;
        }

        [Header("Info")] public Info Infornation;
        [System.Serializable]
        public struct Stat
        {
            public int currency;
            public int XP;
        }
        [Header("Reward")] public Stat Reward = new Stat { currency = 10, XP = 10 };
        public abstract class QuestGoal : ScriptableObject
        {
            protected string description;
            public int currentAmount { get; protected set; }

            public int requiredAmount = 1;

            public bool completed { get; protected set; }
            [HideInInspector] public UnityEvent goalCompleted;

            public virtual void Initialize()
            {
                completed = false;
                goalCompleted = new UnityEvent();

            }
            protected void Evaluate()
            {
                if (currentAmount >= requiredAmount)
                    Complete();
            }

            private void Complete()
            {
                completed = true;
                goalCompleted.Invoke();
                goalCompleted.RemoveAllListeners();
            }
            public virtual string GetDescription()
            {
                return description;
            }

            public void Skip()
            {


            }

        }

        public List<QuestGoal> Goals;
        public void Initialize()
        {
            completed = false;
            questCompleted = new QuestCompletedEvent();
            foreach (var _goal in Goals)
            {
                _goal.Initialize();
                _goal.goalCompleted.AddListener(delegate { CheckGoals(); });
            }
        }
        private void CheckGoals()
        {
            completed = Goals.All(g => g.completed);
            if (completed)
            {
                questCompleted.Invoke(this);
                questCompleted.RemoveAllListeners();
            }
        }

        public class QuestCompletedEvent : UnityEvent<Quest>
        {

        }

#if UNITY_EDITOR
        [CustomEditor(typeof(Quest))]
        public class QuestEditor : Editor
        {
            SerializedProperty m_QuestInfoProperty;
            SerializedProperty m_QuestStatProperty;
            List<string> m_QuestGoaLType;
            SerializedProperty m_QuestGoalListProperty;

            [MenuItem("Assets/Quest", priority = 0)]
            public static void CreateQuest()
            {
                var newQuest = CreateInstance<Quest>();
                ProjectWindowUtil.CreateAsset(newQuest, "quest.asset ");
            }
            void OnEnable()
            {
                m_QuestInfoProperty = serializedObject.FindProperty(nameof(Quest.Infornation));
                m_QuestStatProperty = serializedObject.FindProperty(nameof(Quest.Reward));
                m_QuestGoalListProperty = serializedObject.FindProperty(nameof(Quest.Goals));

                var lookup = typeof(Quest.QuestGoal);
                m_QuestGoal = System.AppDomain.CurrentDomain.GetAssemblies() // Assem
SelectMany(assembly => assembly.GetTypes(0)
Where(x aype => x.IsClass && Ix.IsAbstract && x.IsSubclassOf(Lookul
.Select(type => type.Name) // IEnumerable<string >
Custorm
ToList O: // List<string>
        }
        }
#endif

    }
}
