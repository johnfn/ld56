using Godot;


public partial class CookingIngredient : Button {
  public static CookingIngredient New() {
    return GD.Load<PackedScene>("res://Scenes/cooking_ingredient.tscn").Instantiate<CookingIngredient>();
  }
  public CookingIngredient() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class CookingIngredientNodes {
    CookingIngredient parent;

    public CookingIngredientNodes(CookingIngredient parent) {
      this.parent = parent;
    }
    private TextureRect? _IngredientImage;
    public TextureRect IngredientImage {
      get => _IngredientImage ??= parent.GetNode<TextureRect>("IngredientImage");
    }

    private RichTextLabel? _NameLabel;
    public RichTextLabel NameLabel {
      get => _NameLabel ??= parent.GetNode<RichTextLabel>("NameLabel");
    }

    private Label? _QuantityLabel;
    public Label QuantityLabel {
      get => _QuantityLabel ??= parent.GetNode<Label>("QuantityLabel");
    }

  }

  public CookingIngredientNodes? _Nodes;
  public CookingIngredientNodes Nodes {
    get {
      return _Nodes ??= new CookingIngredientNodes(this);
    }
  }
}
