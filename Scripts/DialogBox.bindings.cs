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

    private TextureRect? _HBoxContainer_CharacterDialogSprite;
    public TextureRect HBoxContainer_CharacterDialogSprite {
      get => _HBoxContainer_CharacterDialogSprite ??= parent.GetNode<TextureRect>("HBoxContainer/CharacterDialogSprite");
    }

    private Label? _HBoxContainer_CharacterDialogSprite_CharacterName;
    public Label HBoxContainer_CharacterDialogSprite_CharacterName {
      get => _HBoxContainer_CharacterDialogSprite_CharacterName ??= parent.GetNode<Label>("HBoxContainer/CharacterDialogSprite/CharacterName");
    }

    private VBoxContainer? _HBoxContainer_CharacterDialogSprite_VBoxContainer;
    public VBoxContainer HBoxContainer_CharacterDialogSprite_VBoxContainer {
      get => _HBoxContainer_CharacterDialogSprite_VBoxContainer ??= parent.GetNode<VBoxContainer>("HBoxContainer/CharacterDialogSprite/VBoxContainer");
    }

    private PanelContainer? _HBoxContainer_CharacterDialogSprite_VBoxContainer_PanelContainer;
    public PanelContainer HBoxContainer_CharacterDialogSprite_VBoxContainer_PanelContainer {
      get => _HBoxContainer_CharacterDialogSprite_VBoxContainer_PanelContainer ??= parent.GetNode<PanelContainer>("HBoxContainer/CharacterDialogSprite/VBoxContainer/PanelContainer");
    }

    private RichTextLabel? _HBoxContainer_CharacterDialogSprite_VBoxContainer_PanelContainer_DialogText;
    public RichTextLabel HBoxContainer_CharacterDialogSprite_VBoxContainer_PanelContainer_DialogText {
      get => _HBoxContainer_CharacterDialogSprite_VBoxContainer_PanelContainer_DialogText ??= parent.GetNode<RichTextLabel>("HBoxContainer/CharacterDialogSprite/VBoxContainer/PanelContainer/DialogText");
    }

    private Label? _HBoxContainer_CharacterDialogSprite_VBoxContainer_PanelContainer_DialogText_ClickToContinue;
    public Label HBoxContainer_CharacterDialogSprite_VBoxContainer_PanelContainer_DialogText_ClickToContinue {
      get => _HBoxContainer_CharacterDialogSprite_VBoxContainer_PanelContainer_DialogText_ClickToContinue ??= parent.GetNode<Label>("HBoxContainer/CharacterDialogSprite/VBoxContainer/PanelContainer/DialogText/ClickToContinue");
    }

    private VBoxContainer? _HBoxContainer_DialogTextVBoxContainer;
    public VBoxContainer HBoxContainer_DialogTextVBoxContainer {
      get => _HBoxContainer_DialogTextVBoxContainer ??= parent.GetNode<VBoxContainer>("HBoxContainer/DialogTextVBoxContainer");
    }

    private VBoxContainer? _HBoxContainer_OptionsVBoxContainer;
    public VBoxContainer HBoxContainer_OptionsVBoxContainer {
      get => _HBoxContainer_OptionsVBoxContainer ??= parent.GetNode<VBoxContainer>("HBoxContainer/OptionsVBoxContainer");
    }

  }

  public DialogBoxNodes? _Nodes;
  public DialogBoxNodes Nodes {
    get {
      return _Nodes ??= new DialogBoxNodes(this);
    }
  }
}
