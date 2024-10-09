using Godot;


public partial class RolodexIngredientEntry : PanelContainer {
  public static RolodexIngredientEntry New() {
    return GD.Load<PackedScene>("res://Scenes/RolodexIngredientEntry.tscn").Instantiate<RolodexIngredientEntry>();
  }
  public RolodexIngredientEntry() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class RolodexIngredientEntryNodes {
    RolodexIngredientEntry parent;

    public RolodexIngredientEntryNodes(RolodexIngredientEntry parent) {
      this.parent = parent;
    }
    private HBoxContainer? _HBoxContainer;
    public HBoxContainer HBoxContainer {
      get => _HBoxContainer ??= parent.GetNode<HBoxContainer>("HBoxContainer");
    }

    private TextureRect? _HBoxContainer_TextureRect;
    public TextureRect HBoxContainer_TextureRect {
      get => _HBoxContainer_TextureRect ??= parent.GetNode<TextureRect>("HBoxContainer/TextureRect");
    }

    private PanelContainer? _HBoxContainer_TextureRect_AddLabel;
    public PanelContainer HBoxContainer_TextureRect_AddLabel {
      get => _HBoxContainer_TextureRect_AddLabel ??= parent.GetNode<PanelContainer>("HBoxContainer/TextureRect/AddLabel");
    }

    private Label? _HBoxContainer_TextureRect_AddLabel_Label;
    public Label HBoxContainer_TextureRect_AddLabel_Label {
      get => _HBoxContainer_TextureRect_AddLabel_Label ??= parent.GetNode<Label>("HBoxContainer/TextureRect/AddLabel/Label");
    }

    private VBoxContainer? _HBoxContainer_TextContainer;
    public VBoxContainer HBoxContainer_TextContainer {
      get => _HBoxContainer_TextContainer ??= parent.GetNode<VBoxContainer>("HBoxContainer/TextContainer");
    }

    private Label? _HBoxContainer_TextContainer_Name;
    public Label HBoxContainer_TextContainer_Name {
      get => _HBoxContainer_TextContainer_Name ??= parent.GetNode<Label>("HBoxContainer/TextContainer/Name");
    }

    private Label? _HBoxContainer_TextContainer_Description;
    public Label HBoxContainer_TextContainer_Description {
      get => _HBoxContainer_TextContainer_Description ??= parent.GetNode<Label>("HBoxContainer/TextContainer/Description");
    }

    private Button? _Button;
    public Button Button {
      get => _Button ??= parent.GetNode<Button>("Button");
    }

    private Label? _Quantity;
    public Label Quantity {
      get => _Quantity ??= parent.GetNode<Label>("Quantity");
    }

  }

  public RolodexIngredientEntryNodes? _Nodes;
  public RolodexIngredientEntryNodes Nodes {
    get {
      return _Nodes ??= new RolodexIngredientEntryNodes(this);
    }
  }
}
