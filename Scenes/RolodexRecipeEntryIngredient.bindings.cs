using Godot;


public partial class RolodexRecipeEntryIngredient : TextureRect {
  public static RolodexRecipeEntryIngredient New() {
    return GD.Load<PackedScene>("res://Scenes/RolodexRecipeEntry_Ingredient.tscn").Instantiate<RolodexRecipeEntryIngredient>();
  }
  public RolodexRecipeEntryIngredient() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class RolodexRecipeEntryIngredientNodes {
    RolodexRecipeEntryIngredient parent;

    public RolodexRecipeEntryIngredientNodes(RolodexRecipeEntryIngredient parent) {
      this.parent = parent;
    }
    // Scene: ./Scenes/RolodexRecipeEntry_Ingredient.tscn
    private Label? _QuestionMark;
    public Label QuestionMark {
      get => _QuestionMark ??= parent.GetNode<Label>("QuestionMark");
    }

  }

  public RolodexRecipeEntryIngredientNodes? _Nodes;
  public RolodexRecipeEntryIngredientNodes Nodes {
    get {
      return _Nodes ??= new RolodexRecipeEntryIngredientNodes(this);
    }
  }
}
