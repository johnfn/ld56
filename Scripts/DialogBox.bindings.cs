using Godot;
namespace ld56;

public partial class DialogBox : PanelContainer {
  public static DialogBox New() {
    return GD.Load<PackedScene>("res://Scenes/dialog_box.tscn").Instantiate<DialogBox>();
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

    private VBoxContainer? _HBoxContainer_DialogTextVBoxContainer;
    public VBoxContainer HBoxContainer_DialogTextVBoxContainer {
      get => _HBoxContainer_DialogTextVBoxContainer ??= parent.GetNode<VBoxContainer>("HBoxContainer/DialogTextVBoxContainer");
    }

    private RichTextLabel? _HBoxContainer_DialogTextVBoxContainer_DialogText;
    public RichTextLabel HBoxContainer_DialogTextVBoxContainer_DialogText {
      get => _HBoxContainer_DialogTextVBoxContainer_DialogText ??= parent.GetNode<RichTextLabel>("HBoxContainer/DialogTextVBoxContainer/DialogText");
    }

    private Label? _HBoxContainer_DialogTextVBoxContainer_ClickToContinue;
    public Label HBoxContainer_DialogTextVBoxContainer_ClickToContinue {
      get => _HBoxContainer_DialogTextVBoxContainer_ClickToContinue ??= parent.GetNode<Label>("HBoxContainer/DialogTextVBoxContainer/ClickToContinue");
    }

    private VBoxContainer? _HBoxContainer_OptionsVBoxContainer;
    public VBoxContainer HBoxContainer_OptionsVBoxContainer {
      get => _HBoxContainer_OptionsVBoxContainer ??= parent.GetNode<VBoxContainer>("HBoxContainer/OptionsVBoxContainer");
    }

    private Label? _HBoxContainer_OptionsVBoxContainer_ClickToContinue;
    public Label HBoxContainer_OptionsVBoxContainer_ClickToContinue {
      get => _HBoxContainer_OptionsVBoxContainer_ClickToContinue ??= parent.GetNode<Label>("HBoxContainer/OptionsVBoxContainer/ClickToContinue");
    }

  }

  public DialogBoxNodes? _Nodes;
  public DialogBoxNodes Nodes {
    get {
      return _Nodes ??= new DialogBoxNodes(this);
    }
  }
}
