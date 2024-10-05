using Godot;
namespace ld56;

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

    private VBoxContainer? _HBoxContainer_VBoxContainer2;
    public VBoxContainer HBoxContainer_VBoxContainer2 {
      get => _HBoxContainer_VBoxContainer2 ??= parent.GetNode<VBoxContainer>("HBoxContainer/VBoxContainer2");
    }

    private Label? _HBoxContainer_VBoxContainer2_DialogText;
    public Label HBoxContainer_VBoxContainer2_DialogText {
      get => _HBoxContainer_VBoxContainer2_DialogText ??= parent.GetNode<Label>("HBoxContainer/VBoxContainer2/DialogText");
    }

    private Label? _HBoxContainer_VBoxContainer2_ClickToContinue;
    public Label HBoxContainer_VBoxContainer2_ClickToContinue {
      get => _HBoxContainer_VBoxContainer2_ClickToContinue ??= parent.GetNode<Label>("HBoxContainer/VBoxContainer2/ClickToContinue");
    }

  }

  public DialogBoxNodes? _Nodes;
  public DialogBoxNodes Nodes {
    get {
      return _Nodes ??= new DialogBoxNodes(this);
    }
  }
}
