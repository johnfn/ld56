using Godot;


public partial class CookingIngredient : Container {
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

    private PanelContainer? _PanelContainer;
    public PanelContainer PanelContainer {
      get => _PanelContainer ??= parent.GetNode<PanelContainer>("PanelContainer");
    }

    private MarginContainer? _PanelContainer_MarginContainer;
    public MarginContainer PanelContainer_MarginContainer {
      get => _PanelContainer_MarginContainer ??= parent.GetNode<MarginContainer>("PanelContainer/MarginContainer");
    }

    private Label? _PanelContainer_MarginContainer_QuantityLabel;
    public Label PanelContainer_MarginContainer_QuantityLabel {
      get => _PanelContainer_MarginContainer_QuantityLabel ??= parent.GetNode<Label>("PanelContainer/MarginContainer/QuantityLabel");
    }

    private Control? _Control;
    public Control Control {
      get => _Control ??= parent.GetNode<Control>("Control");
    }

    private PanelContainer? _Control_Tooltip;
    public PanelContainer Control_Tooltip {
      get => _Control_Tooltip ??= parent.GetNode<PanelContainer>("Control/Tooltip");
    }

    private MarginContainer? _Control_Tooltip_MarginContainer;
    public MarginContainer Control_Tooltip_MarginContainer {
      get => _Control_Tooltip_MarginContainer ??= parent.GetNode<MarginContainer>("Control/Tooltip/MarginContainer");
    }

    private VBoxContainer? _Control_Tooltip_MarginContainer_VBoxContainer;
    public VBoxContainer Control_Tooltip_MarginContainer_VBoxContainer {
      get => _Control_Tooltip_MarginContainer_VBoxContainer ??= parent.GetNode<VBoxContainer>("Control/Tooltip/MarginContainer/VBoxContainer");
    }

    private RichTextLabel? _Control_Tooltip_MarginContainer_VBoxContainer_Title;
    public RichTextLabel Control_Tooltip_MarginContainer_VBoxContainer_Title {
      get => _Control_Tooltip_MarginContainer_VBoxContainer_Title ??= parent.GetNode<RichTextLabel>("Control/Tooltip/MarginContainer/VBoxContainer/Title");
    }

    private RichTextLabel? _Control_Tooltip_MarginContainer_VBoxContainer_Description;
    public RichTextLabel Control_Tooltip_MarginContainer_VBoxContainer_Description {
      get => _Control_Tooltip_MarginContainer_VBoxContainer_Description ??= parent.GetNode<RichTextLabel>("Control/Tooltip/MarginContainer/VBoxContainer/Description");
    }

    private RichTextLabel? _Control_Tooltip_MarginContainer_VBoxContainer_Price;
    public RichTextLabel Control_Tooltip_MarginContainer_VBoxContainer_Price {
      get => _Control_Tooltip_MarginContainer_VBoxContainer_Price ??= parent.GetNode<RichTextLabel>("Control/Tooltip/MarginContainer/VBoxContainer/Price");
    }

    private TextureRect? _TextureRect;
    public TextureRect TextureRect {
      get => _TextureRect ??= parent.GetNode<TextureRect>("TextureRect");
    }

    private Button? _Button;
    public Button Button {
      get => _Button ??= parent.GetNode<Button>("Button");
    }

  }

  public CookingIngredientNodes? _Nodes;
  public CookingIngredientNodes Nodes {
    get {
      return _Nodes ??= new CookingIngredientNodes(this);
    }
  }
}
