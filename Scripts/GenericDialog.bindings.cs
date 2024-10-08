using Godot;


public partial class GenericDialog : PanelContainer {
  public static GenericDialog New() {
    return GD.Load<PackedScene>("res://Scenes/generic_dialog.tscn").Instantiate<GenericDialog>();
  }
  public GenericDialog() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class GenericDialogNodes {
    GenericDialog parent;

    public GenericDialogNodes(GenericDialog parent) {
      this.parent = parent;
    }
    // Scene: ./Scenes/generic_dialog.tscn
    private MarginContainer? _MarginContainer;
    public MarginContainer MarginContainer {
      get => _MarginContainer ??= parent.GetNode<MarginContainer>("MarginContainer");
    }

    private VBoxContainer? _MarginContainer_VBoxContainer;
    public VBoxContainer MarginContainer_VBoxContainer {
      get => _MarginContainer_VBoxContainer ??= parent.GetNode<VBoxContainer>("MarginContainer/VBoxContainer");
    }

    private Label? _MarginContainer_VBoxContainer_Label;
    public Label MarginContainer_VBoxContainer_Label {
      get => _MarginContainer_VBoxContainer_Label ??= parent.GetNode<Label>("MarginContainer/VBoxContainer/Label");
    }

    private Control? _MarginContainer_VBoxContainer_Control;
    public Control MarginContainer_VBoxContainer_Control {
      get => _MarginContainer_VBoxContainer_Control ??= parent.GetNode<Control>("MarginContainer/VBoxContainer/Control");
    }

    private Button? _MarginContainer_VBoxContainer_Button;
    public Button MarginContainer_VBoxContainer_Button {
      get => _MarginContainer_VBoxContainer_Button ??= parent.GetNode<Button>("MarginContainer/VBoxContainer/Button");
    }

  }

  public GenericDialogNodes? _Nodes;
  public GenericDialogNodes Nodes {
    get {
      return _Nodes ??= new GenericDialogNodes(this);
    }
  }
}
