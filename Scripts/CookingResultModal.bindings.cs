using Godot;


public partial class CookingResultModal : PanelContainer {
  public static CookingResultModal New() {
    return GD.Load<PackedScene>("res://Scenes/cooking_result_modal.tscn").Instantiate<CookingResultModal>();
  }
  public CookingResultModal() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class CookingResultModalNodes {
    CookingResultModal parent;

    public CookingResultModalNodes(CookingResultModal parent) {
      this.parent = parent;
    }
    private VBoxContainer? _HBoxContainer;
    public VBoxContainer HBoxContainer {
      get => _HBoxContainer ??= parent.GetNode<VBoxContainer>("HBoxContainer");
    }

    private Label? _HBoxContainer_Title;
    public Label HBoxContainer_Title {
      get => _HBoxContainer_Title ??= parent.GetNode<Label>("HBoxContainer/Title");
    }

    private Control? _HBoxContainer_Spacer;
    public Control HBoxContainer_Spacer {
      get => _HBoxContainer_Spacer ??= parent.GetNode<Control>("HBoxContainer/Spacer");
    }

    private Label? _HBoxContainer_Result;
    public Label HBoxContainer_Result {
      get => _HBoxContainer_Result ??= parent.GetNode<Label>("HBoxContainer/Result");
    }

    private Label? _HBoxContainer_Description;
    public Label HBoxContainer_Description {
      get => _HBoxContainer_Description ??= parent.GetNode<Label>("HBoxContainer/Description");
    }

    private Control? _HBoxContainer_Spacer2;
    public Control HBoxContainer_Spacer2 {
      get => _HBoxContainer_Spacer2 ??= parent.GetNode<Control>("HBoxContainer/Spacer2");
    }

    private Button? _HBoxContainer_Confirm;
    public Button HBoxContainer_Confirm {
      get => _HBoxContainer_Confirm ??= parent.GetNode<Button>("HBoxContainer/Confirm");
    }

  }

  public CookingResultModalNodes? _Nodes;
  public CookingResultModalNodes Nodes {
    get {
      return _Nodes ??= new CookingResultModalNodes(this);
    }
  }
}
