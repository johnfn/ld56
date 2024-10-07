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
    // Scene: ./Scenes/cooking_ingredient.tscn
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

    private PanelContainer? _Tooltip;
    public PanelContainer Tooltip {
      get => _Tooltip ??= parent.GetNode<PanelContainer>("Tooltip");
    }

    private MarginContainer? _Tooltip_MarginContainer;
    public MarginContainer Tooltip_MarginContainer {
      get => _Tooltip_MarginContainer ??= parent.GetNode<MarginContainer>("Tooltip/MarginContainer");
    }

    private VBoxContainer? _Tooltip_MarginContainer_VBoxContainer;
    public VBoxContainer Tooltip_MarginContainer_VBoxContainer {
      get => _Tooltip_MarginContainer_VBoxContainer ??= parent.GetNode<VBoxContainer>("Tooltip/MarginContainer/VBoxContainer");
    }

    private RichTextLabel? _Tooltip_MarginContainer_VBoxContainer_Title;
    public RichTextLabel Tooltip_MarginContainer_VBoxContainer_Title {
      get => _Tooltip_MarginContainer_VBoxContainer_Title ??= parent.GetNode<RichTextLabel>("Tooltip/MarginContainer/VBoxContainer/Title");
    }

    private RichTextLabel? _Tooltip_MarginContainer_VBoxContainer_Description;
    public RichTextLabel Tooltip_MarginContainer_VBoxContainer_Description {
      get => _Tooltip_MarginContainer_VBoxContainer_Description ??= parent.GetNode<RichTextLabel>("Tooltip/MarginContainer/VBoxContainer/Description");
    }

    private RichTextLabel? _Tooltip_MarginContainer_VBoxContainer_Price;
    public RichTextLabel Tooltip_MarginContainer_VBoxContainer_Price {
      get => _Tooltip_MarginContainer_VBoxContainer_Price ??= parent.GetNode<RichTextLabel>("Tooltip/MarginContainer/VBoxContainer/Price");
    }

  }

  public CookingIngredientNodes? _Nodes;
  public CookingIngredientNodes Nodes {
    get {
      return _Nodes ??= new CookingIngredientNodes(this);
    }
  }
}
