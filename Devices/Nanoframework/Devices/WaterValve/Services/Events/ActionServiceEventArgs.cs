using System;
using WaterValve.Models;

namespace WaterValve.Services.Events
{
    public class ActionServiceEventArgs
    {
        public EventType Type { get; set; }
        public string Message { get; set; }

        public ActionServiceEventArgs(EventType type, string message)
        {
            Type = type;
            Message = message ?? throw new ArgumentNullException(nameof(message));
        }
    }
}