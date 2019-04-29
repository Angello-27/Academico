namespace Academico.Common.Models
{
    using Newtonsoft.Json;

    public partial class Student
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("imageUrl")]
        public object ImageUrl { get; set; }

        [JsonProperty("isAvailable")]
        public bool IsAvailable { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("imageFullPath")]
        public object ImageFullPath { get; set; }

        public override string ToString()
        {
            return $"{this.Name} {this.LastName}";
        }
    }

}
