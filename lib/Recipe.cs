namespace Hangry.Lib;

public class Recipe
{
    public int id { get; set; }
    public string name { get; set; }
    public string avg_rating { get; set; }
    public int num_ratings { get; set; }
    public string image_url { get; set; }
    public List<string> ingredients { get; set; }
    public List<string> cooking_directions { get; set; }

    // These values don't come from the JSon, we parse them from the cooking directions list
    public string Prep { get; private set; }
    public string Cook { get; private set; }
    public string Ready { get; private set; }

    internal bool ParseTimeData()
    {
        // Usually the 2nd, 4th and 6th elements have the time data
        // TODO: Potential improvement: more specific parsing
        if (this.cooking_directions is not null && this.cooking_directions.Count > 6)
        {
            this.Prep = this.cooking_directions[1];
            this.Cook = this.cooking_directions[3];
            this.Ready = this.cooking_directions[5];

            this.cooking_directions.RemoveRange(0, 6);

            // The last direction always has two unnecessary characters at the end
            var lastDirection = this.cooking_directions.Last();
            this.cooking_directions[this.cooking_directions.Count - 1] = lastDirection[..^2];
            return true;
        }

        return false;
    }
}
