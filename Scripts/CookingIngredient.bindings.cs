using Godot;


public partial class CookingIngredient : PanelContainer {
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
    private TextureRect? _TextureRect;
    public TextureRect TextureRect {
      get => _TextureRect ??= parent.GetNode<TextureRect>("TextureRect");
    }

    private RichTextLabel? _TextureRect_NameLabel;
    public RichTextLabel TextureRect_NameLabel {
      get => _TextureRect_NameLabel ??= parent.GetNode<RichTextLabel>("TextureRect/NameLabel");
    }

    private PanelContainer? _TextureRect_PanelContainer;
    public PanelContainer TextureRect_PanelContainer {
      get => _TextureRect_PanelContainer ??= parent.GetNode<PanelContainer>("TextureRect/PanelContainer");
    }

    private MarginContainer? _TextureRect_PanelContainer_MarginContainer;
    public MarginContainer TextureRect_PanelContainer_MarginContainer {
      get => _TextureRect_PanelContainer_MarginContainer ??= parent.GetNode<MarginContainer>("TextureRect/PanelContainer/MarginContainer");
    }

    private Label? _TextureRect_PanelContainer_MarginContainer_QuantityLabel;
    public Label TextureRect_PanelContainer_MarginContainer_QuantityLabel {
      get => _TextureRect_PanelContainer_MarginContainer_QuantityLabel ??= parent.GetNode<Label>("TextureRect/PanelContainer/MarginContainer/QuantityLabel");
    }

    private Control? _TextureRect_Control;
    public Control TextureRect_Control {
      get => _TextureRect_Control ??= parent.GetNode<Control>("TextureRect/Control");
    }

    private PanelContainer? _TextureRect_Control_Tooltip;
    public PanelContainer TextureRect_Control_Tooltip {
      get => _TextureRect_Control_Tooltip ??= parent.GetNode<PanelContainer>("TextureRect/Control/Tooltip");
    }

    private MarginContainer? _TextureRect_Control_Tooltip_MarginContainer;
    public MarginContainer TextureRect_Control_Tooltip_MarginContainer {
      get => _TextureRect_Control_Tooltip_MarginContainer ??= parent.GetNode<MarginContainer>("TextureRect/Control/Tooltip/MarginContainer");
    }

    private VBoxContainer? _TextureRect_Control_Tooltip_MarginContainer_VBoxContainer;
    public VBoxContainer TextureRect_Control_Tooltip_MarginContainer_VBoxContainer {
      get => _TextureRect_Control_Tooltip_MarginContainer_VBoxContainer ??= parent.GetNode<VBoxContainer>("TextureRect/Control/Tooltip/MarginContainer/VBoxContainer");
    }

    private RichTextLabel? _TextureRect_Control_Tooltip_MarginContainer_VBoxContainer_Title;
    public RichTextLabel TextureRect_Control_Tooltip_MarginContainer_VBoxContainer_Title {
      get => _TextureRect_Control_Tooltip_MarginContainer_VBoxContainer_Title ??= parent.GetNode<RichTextLabel>("TextureRect/Control/Tooltip/MarginContainer/VBoxContainer/Title");
    }

    private RichTextLabel? _TextureRect_Control_Tooltip_MarginContainer_VBoxContainer_Description;
    public RichTextLabel TextureRect_Control_Tooltip_MarginContainer_VBoxContainer_Description {
      get => _TextureRect_Control_Tooltip_MarginContainer_VBoxContainer_Description ??= parent.GetNode<RichTextLabel>("TextureRect/Control/Tooltip/MarginContainer/VBoxContainer/Description");
    }

    private Control? _TextureRect_Control_Tooltip_MarginContainer_VBoxContainer_Control;
    public Control TextureRect_Control_Tooltip_MarginContainer_VBoxContainer_Control {
      get => _TextureRect_Control_Tooltip_MarginContainer_VBoxContainer_Control ??= parent.GetNode<Control>("TextureRect/Control/Tooltip/MarginContainer/VBoxContainer/Control");
    }

    private RichTextLabel? _TextureRect_Control_Tooltip_MarginContainer_VBoxContainer_Price;
    public RichTextLabel TextureRect_Control_Tooltip_MarginContainer_VBoxContainer_Price {
      get => _TextureRect_Control_Tooltip_MarginContainer_VBoxContainer_Price ??= parent.GetNode<RichTextLabel>("TextureRect/Control/Tooltip/MarginContainer/VBoxContainer/Price");
    }

    private Button? _TextureRect_Button;
    public Button TextureRect_Button {
      get => _TextureRect_Button ??= parent.GetNode<Button>("TextureRect/Button");
    }

  }

  public CookingIngredientNodes? _Nodes;
  public CookingIngredientNodes Nodes {
    get {
      return _Nodes ??= new CookingIngredientNodes(this);
    }
  }
}
