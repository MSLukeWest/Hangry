namespace Hangry.Lib;

public class Recipe
{
    public int id { get; set; }
    public string name { get; set; }
    public string avg_rating { get; set; }
    public int num_ratings { get; set; }
    public string img_url { get; set; }
    public List<string> ingredients { get; set; }
}
