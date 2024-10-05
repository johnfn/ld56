using System.Collections.Generic;

namespace ld56;

public class Recipe {
  public string Name { get; set; }
  public string Description { get; set; }
  public List<Ingredient> Ingredients { get; set; }
}
