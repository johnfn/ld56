using Godot;


public partial class PauseMenu : ColorRect {
  public static PauseMenu New() {
    return GD.Load<PackedScene>("res://Scenes/PauseMenu.tscn").Instantiate<PauseMenu>();
  }
  public PauseMenu() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class PauseMenuNodes {
    PauseMenu parent;

    public PauseMenuNodes(PauseMenu parent) {
      this.parent = parent;
    }
    // Scene: ./Scenes/PauseMenu.tscn
    private TextureRect? _Background;
    public TextureRect Background {
      get => _Background ??= parent.GetNode<TextureRect>("Background");
    }

    private VBoxContainer? _Background_CreditsContent;
    public VBoxContainer Background_CreditsContent {
      get => _Background_CreditsContent ??= parent.GetNode<VBoxContainer>("Background/CreditsContent");
    }

    private MarginContainer? _Background_CreditsContent_MarginContainer3;
    public MarginContainer Background_CreditsContent_MarginContainer3 {
      get => _Background_CreditsContent_MarginContainer3 ??= parent.GetNode<MarginContainer>("Background/CreditsContent/MarginContainer3");
    }

    private Label? _Background_CreditsContent_MarginContainer3_Credits;
    public Label Background_CreditsContent_MarginContainer3_Credits {
      get => _Background_CreditsContent_MarginContainer3_Credits ??= parent.GetNode<Label>("Background/CreditsContent/MarginContainer3/Credits");
    }

    private Control? _Background_CreditsContent_Spacer;
    public Control Background_CreditsContent_Spacer {
      get => _Background_CreditsContent_Spacer ??= parent.GetNode<Control>("Background/CreditsContent/Spacer");
    }

    private MarginContainer? _Background_CreditsContent_MarginContainer;
    public MarginContainer Background_CreditsContent_MarginContainer {
      get => _Background_CreditsContent_MarginContainer ??= parent.GetNode<MarginContainer>("Background/CreditsContent/MarginContainer");
    }

    private Label? _Background_CreditsContent_MarginContainer_Name;
    public Label Background_CreditsContent_MarginContainer_Name {
      get => _Background_CreditsContent_MarginContainer_Name ??= parent.GetNode<Label>("Background/CreditsContent/MarginContainer/Name");
    }

    private Control? _Background_CreditsContent_Spacer2;
    public Control Background_CreditsContent_Spacer2 {
      get => _Background_CreditsContent_Spacer2 ??= parent.GetNode<Control>("Background/CreditsContent/Spacer2");
    }

    private MarginContainer? _Background_CreditsContent_MarginContainer2;
    public MarginContainer Background_CreditsContent_MarginContainer2 {
      get => _Background_CreditsContent_MarginContainer2 ??= parent.GetNode<MarginContainer>("Background/CreditsContent/MarginContainer2");
    }

    private Button? _Background_CreditsContent_MarginContainer2_BackButton;
    public Button Background_CreditsContent_MarginContainer2_BackButton {
      get => _Background_CreditsContent_MarginContainer2_BackButton ??= parent.GetNode<Button>("Background/CreditsContent/MarginContainer2/BackButton");
    }

    private VBoxContainer? _Background_MainMenuContent;
    public VBoxContainer Background_MainMenuContent {
      get => _Background_MainMenuContent ??= parent.GetNode<VBoxContainer>("Background/MainMenuContent");
    }

    private Label? _Background_MainMenuContent_Credits;
    public Label Background_MainMenuContent_Credits {
      get => _Background_MainMenuContent_Credits ??= parent.GetNode<Label>("Background/MainMenuContent/Credits");
    }

    private Control? _Background_MainMenuContent_Spacer;
    public Control Background_MainMenuContent_Spacer {
      get => _Background_MainMenuContent_Spacer ??= parent.GetNode<Control>("Background/MainMenuContent/Spacer");
    }

    private VBoxContainer? _Background_MainMenuContent_ButtonsContainer;
    public VBoxContainer Background_MainMenuContent_ButtonsContainer {
      get => _Background_MainMenuContent_ButtonsContainer ??= parent.GetNode<VBoxContainer>("Background/MainMenuContent/ButtonsContainer");
    }

    private Button? _Background_MainMenuContent_ButtonsContainer_Play;
    public Button Background_MainMenuContent_ButtonsContainer_Play {
      get => _Background_MainMenuContent_ButtonsContainer_Play ??= parent.GetNode<Button>("Background/MainMenuContent/ButtonsContainer/Play");
    }

    private Button? _Background_MainMenuContent_ButtonsContainer_Credits;
    public Button Background_MainMenuContent_ButtonsContainer_Credits {
      get => _Background_MainMenuContent_ButtonsContainer_Credits ??= parent.GetNode<Button>("Background/MainMenuContent/ButtonsContainer/Credits");
    }

    private Button? _Background_MainMenuContent_ButtonsContainer_Exit;
    public Button Background_MainMenuContent_ButtonsContainer_Exit {
      get => _Background_MainMenuContent_ButtonsContainer_Exit ??= parent.GetNode<Button>("Background/MainMenuContent/ButtonsContainer/Exit");
    }

    private VBoxContainer? _Background_PauseMenuContent;
    public VBoxContainer Background_PauseMenuContent {
      get => _Background_PauseMenuContent ??= parent.GetNode<VBoxContainer>("Background/PauseMenuContent");
    }

    private Label? _Background_PauseMenuContent_Credits;
    public Label Background_PauseMenuContent_Credits {
      get => _Background_PauseMenuContent_Credits ??= parent.GetNode<Label>("Background/PauseMenuContent/Credits");
    }

    private Control? _Background_PauseMenuContent_Spacer;
    public Control Background_PauseMenuContent_Spacer {
      get => _Background_PauseMenuContent_Spacer ??= parent.GetNode<Control>("Background/PauseMenuContent/Spacer");
    }

    private VBoxContainer? _Background_PauseMenuContent_ButtonsContainer;
    public VBoxContainer Background_PauseMenuContent_ButtonsContainer {
      get => _Background_PauseMenuContent_ButtonsContainer ??= parent.GetNode<VBoxContainer>("Background/PauseMenuContent/ButtonsContainer");
    }

    private Button? _Background_PauseMenuContent_ButtonsContainer_Resume;
    public Button Background_PauseMenuContent_ButtonsContainer_Resume {
      get => _Background_PauseMenuContent_ButtonsContainer_Resume ??= parent.GetNode<Button>("Background/PauseMenuContent/ButtonsContainer/Resume");
    }

    private Button? _Background_PauseMenuContent_ButtonsContainer_Credits;
    public Button Background_PauseMenuContent_ButtonsContainer_Credits {
      get => _Background_PauseMenuContent_ButtonsContainer_Credits ??= parent.GetNode<Button>("Background/PauseMenuContent/ButtonsContainer/Credits");
    }

    private Button? _Background_PauseMenuContent_ButtonsContainer_MainMenu;
    public Button Background_PauseMenuContent_ButtonsContainer_MainMenu {
      get => _Background_PauseMenuContent_ButtonsContainer_MainMenu ??= parent.GetNode<Button>("Background/PauseMenuContent/ButtonsContainer/MainMenu");
    }

  }

  public PauseMenuNodes? _Nodes;
  public PauseMenuNodes Nodes {
    get {
      return _Nodes ??= new PauseMenuNodes(this);
    }
  }
}
