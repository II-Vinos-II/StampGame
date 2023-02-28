using UnityEngine;

namespace @internal.NF.NFEditor.Editor
{
    [CreateAssetMenu(fileName = "reminderinfo", menuName = "Reset Reminder Script", order = 10)]
    public class ReminderInfo : ScriptableObject
    {
        public string text;

        public bool isRead;
    }
}