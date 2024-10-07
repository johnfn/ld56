using Godot;
namespace ld56;

public partial class DialogBox : Control {
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
    // Scene: ./Scenes/dialog_box.tscn
    private ColorRect? _Background;
    public ColorRect Background {
      get => _Background ??= parent.GetNode<ColorRect>("Background");
    }

    private PanelContainer? _DialogBox_;
    public PanelContainer DialogBox_ {
      get => _DialogBox_ ??= parent.GetNode<PanelContainer>("DialogBox");
    }

    private HBoxContainer? _DialogBox_HBoxContainer;
    public HBoxContainer DialogBox_HBoxContainer {
      get => _DialogBox_HBoxContainer ??= parent.GetNode<HBoxContainer>("DialogBox/HBoxContainer");
    }

    private TextureRect? _DialogBox_HBoxContainer_CharacterDialogSprite;
    public TextureRect DialogBox_HBoxContainer_CharacterDialogSprite {
      get => _DialogBox_HBoxContainer_CharacterDialogSprite ??= parent.GetNode<TextureRect>("DialogBox/HBoxContainer/CharacterDialogSprite");
    }

    private Label? _DialogBox_HBoxContainer_CharacterDialogSprite_CharacterName;
    public Label DialogBox_HBoxContainer_CharacterDialogSprite_CharacterName {
      get => _DialogBox_HBoxContainer_CharacterDialogSprite_CharacterName ??= parent.GetNode<Label>("DialogBox/HBoxContainer/CharacterDialogSprite/CharacterName");
    }

    private VBoxContainer? _DialogBox_HBoxContainer_CharacterDialogSprite_VBoxContainer;
    public VBoxContainer DialogBox_HBoxContainer_CharacterDialogSprite_VBoxContainer {
      get => _DialogBox_HBoxContainer_CharacterDialogSprite_VBoxContainer ??= parent.GetNode<VBoxContainer>("DialogBox/HBoxContainer/CharacterDialogSprite/VBoxContainer");
    }

    private PanelContainer? _DialogBox_HBoxContainer_CharacterDialogSprite_VBoxContainer_PanelContainer;
    public PanelContainer DialogBox_HBoxContainer_CharacterDialogSprite_VBoxContainer_PanelContainer {
      get => _DialogBox_HBoxContainer_CharacterDialogSprite_VBoxContainer_PanelContainer ??= parent.GetNode<PanelContainer>("DialogBox/HBoxContainer/CharacterDialogSprite/VBoxContainer/PanelContainer");
    }

    private RichTextLabel? _DialogBox_HBoxContainer_CharacterDialogSprite_VBoxContainer_PanelContainer_DialogText;
    public RichTextLabel DialogBox_HBoxContainer_CharacterDialogSprite_VBoxContainer_PanelContainer_DialogText {
      get => _DialogBox_HBoxContainer_CharacterDialogSprite_VBoxContainer_PanelContainer_DialogText ??= parent.GetNode<RichTextLabel>("DialogBox/HBoxContainer/CharacterDialogSprite/VBoxContainer/PanelContainer/DialogText");
    }

    private Label? _DialogBox_HBoxContainer_CharacterDialogSprite_VBoxContainer_PanelContainer_DialogText_ClickToContinue;
    public Label DialogBox_HBoxContainer_CharacterDialogSprite_VBoxContainer_PanelContainer_DialogText_ClickToContinue {
      get => _DialogBox_HBoxContainer_CharacterDialogSprite_VBoxContainer_PanelContainer_DialogText_ClickToContinue ??= parent.GetNode<Label>("DialogBox/HBoxContainer/CharacterDialogSprite/VBoxContainer/PanelContainer/DialogText/ClickToContinue");
    }

    private VBoxContainer? _DialogBox_HBoxContainer_DialogTextVBoxContainer;
    public VBoxContainer DialogBox_HBoxContainer_DialogTextVBoxContainer {
      get => _DialogBox_HBoxContainer_DialogTextVBoxContainer ??= parent.GetNode<VBoxContainer>("DialogBox/HBoxContainer/DialogTextVBoxContainer");
    }

    private VBoxContainer? _DialogBox_HBoxContainer_OptionsVBoxContainer;
    public VBoxContainer DialogBox_HBoxContainer_OptionsVBoxContainer {
      get => _DialogBox_HBoxContainer_OptionsVBoxContainer ??= parent.GetNode<VBoxContainer>("DialogBox/HBoxContainer/OptionsVBoxContainer");
    }

  }

  public DialogBoxNodes? _Nodes;
  public DialogBoxNodes Nodes {
    get {
      return _Nodes ??= new DialogBoxNodes(this);
    }
  }
}
