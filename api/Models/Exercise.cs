using System.Dynamic;

namespace api.models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Distance { get; set; }
        public string Day { get; set; }
        public bool Pinned { get; set; }
    }
}