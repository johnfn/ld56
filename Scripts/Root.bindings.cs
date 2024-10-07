using Godot;
namespace ld56;

public partial class Root : Node2D {
  public static Root New() {
    return GD.Load<PackedScene>("res://Scenes/root.tscn").Instantiate<Root>();
  }
  public Root() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class RootNodes {
    Root parent;

    public RootNodes(Root parent) {
      this.parent = parent;
    }
    // Scene: ./Scenes/root.tscn
    private SoundManager? _SoundManager;
    public SoundManager SoundManager {
      get => _SoundManager ??= parent.GetNode<SoundManager>("SoundManager");
    }

    private Exterior? _Exterior;
    public Exterior Exterior {
      get => _Exterior ??= parent.GetNode<Exterior>("Exterior");
    }

    private Interior? _Interior;
    public Interior Interior {
      get => _Interior ??= parent.GetNode<Interior>("Interior");
    }

    private Rolodex? _Rolodex;
    public Rolodex Rolodex {
      get => _Rolodex ??= parent.GetNode<Rolodex>("Rolodex");
    }

    private Camera? _Camera;
    public Camera Camera {
      get => _Camera ??= parent.GetNode<Camera>("Camera");
    }

    private Hud? _HUD;
    public Hud HUD {
      get => _HUD ??= parent.GetNode<Hud>("HUD");
    }

    private AnimalManager? _AnimalManager;
    public AnimalManager AnimalManager {
      get => _AnimalManager ??= parent.GetNode<AnimalManager>("AnimalManager");
    }

    private CookingScreen? _CookingScreen;
    public CookingScreen CookingScreen {
      get => _CookingScreen ??= parent.GetNode<CookingScreen>("CookingScreen");
    }

  }

  public RootNodes? _Nodes;
  public RootNodes Nodes {
    get {
      return _Nodes ??= new RootNodes(this);
    }
  }
}
