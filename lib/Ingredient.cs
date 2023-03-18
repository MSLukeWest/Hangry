namespace Hangry.Lib;

public class Ingredient
{       
    public Ingredient(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException(null, nameof(name));
        }
        
        this.Name = name;
    }

    public string Name { get; private set; }

    // TODO: Remove if this doesn't get used
    public bool Selected { get; set; } = false;

    public override bool Equals(object obj) => obj is not null && obj is Ingredient other && other.Name == this.Name;

    public override int GetHashCode()
    {
        return this.Name.GetHashCode();
    }
}
