public class Score
{
    public int Id { get; set; }

    // Add "?" to make it nullable OR provide a default value in the constructor
    public string? LevelType { get; set; } = string.Empty;
    public string? Level { get; set; } = string.Empty;
}
