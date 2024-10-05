using Godot;


public partial class DialogBox : PanelContainer {
  public static DialogBox New() {
    return GD.Load<PackedScene>("res://dialog_box.tscn").Instantiate<DialogBox>();
  }
  public DialogBox() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class DialogBoxNodes {
    DialogBox parent;

    public DialogBoxNodes(DialogBox parent) {
      this.parent = parent;
    }
    private HBoxContainer? _HBoxContainer;
    public HBoxContainer HBoxContainer {
      get => _HBoxContainer ??= parent.GetNode<HBoxContainer>("HBoxContainer");
    }

    private VBoxContainer? _HBoxContainer_VBoxContainer;
    public VBoxContainer HBoxContainer_VBoxContainer {
      get => _HBoxContainer_VBoxContainer ??= parent.GetNode<VBoxContainer>("HBoxContainer/VBoxContainer");
    }

    private TextureRect? _HBoxContainer_VBoxContainer_TextureRect;
    public TextureRect HBoxContainer_VBoxContainer_TextureRect {
      get => _HBoxContainer_VBoxContainer_TextureRect ??= parent.GetNode<TextureRect>("HBoxContainer/VBoxContainer/TextureRect");
    }

    private Label? _HBoxContainer_VBoxContainer_Label;
    public Label HBoxContainer_VBoxContainer_Label {
      get => _HBoxContainer_VBoxContainer_Label ??= parent.GetNode<Label>("HBoxContainer/VBoxContainer/Label");
    }

    private Label? _HBoxContainer_Label;
    public Label HBoxContainer_Label {
      get => _HBoxContainer_Label ??= parent.GetNode<Label>("HBoxContainer/Label");
    }

  }

  public DialogBoxNodes? _Nodes;
  public DialogBoxNodes Nodes {
    get {
      return _Nodes ??= new DialogBoxNodes(this);
    }
  }
}
