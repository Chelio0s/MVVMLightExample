

namespace MVVMLigtAdvanced.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PostId { get; set; }

        public Post Post { get; set; }
    }
}
