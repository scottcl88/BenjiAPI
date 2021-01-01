using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.Shared
{
    public partial class IncidentId
    {
        public long Value { get; set; }
    }

    public partial class IncidentModel
    {
        public IncidentId IncidentId { get; set; }
        public DogModel Dog { get; set; }
        public IncidentType IncidentType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime IncidentDate { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public DateTime? Deleted { get; set; }
    }

    public enum IncidentType
    {
        Unknown = 0,
        Pee = 1,
        Poop = 2,
        Diarrhea = 3,

        [Display(Name = "Throw up")]
        ThrowUp = 4,

        Hurt = 5,

        [Display(Name = "Run Away")]
        RanAway = 6
    }

    public static class Extensions
    {
        public static List<string> GetDisplayNames(this Type enm)
        {
            var displaynames = new List<string>();
            var names = Enum.GetNames(enm);
            foreach (var name in names)
            {
                var field = enm.GetField(name);
                var fds = field.GetCustomAttributes(typeof(DisplayAttribute), true);

                if (fds.Length == 0)
                {
                    displaynames.Add(name);
                }

                foreach (DisplayAttribute fd in fds)
                {
                    displaynames.Add(fd.Name);
                }
            }
            return displaynames;
        }

        public static Dictionary<string, int> GetDisplayDictonary(this Type enm)
        {
            var displaynames = new Dictionary<string, int>();
            var names = Enum.GetNames(enm);
            foreach (var name in names)
            {
                var field = enm.GetField(name);
                var fds = field.GetCustomAttributes(typeof(DisplayAttribute), true);

                var enmValue = (int)Enum.Parse(enm, name);

                if (fds.Length == 0)
                {
                    displaynames.Add(name, enmValue);
                }

                foreach (DisplayAttribute fd in fds)
                {
                    displaynames.Add(fd.Name, enmValue);
                }
            }
            return displaynames;
        }
    }
}