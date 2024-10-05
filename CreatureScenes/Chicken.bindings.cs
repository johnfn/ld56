using Godot;
namespace ld56;

public partial class Chicken : Sprite2D {
  public static Chicken New() {
    return GD.Load<PackedScene>("res://CreatureScenes/chicken.tscn").Instantiate<Chicken>();
  }
  public Chicken() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class ChickenNodes {
    Chicken parent;

    public ChickenNodes(Chicken parent) {
      this.parent = parent;
    }
    private HoverPanelExterior? _HoverPanelExterior;
    public HoverPanelExterior HoverPanelExterior {
      get => _HoverPanelExterior ??= parent.GetNode<HoverPanelExterior>("HoverPanelExterior");
    }

  }

  public ChickenNodes? _Nodes;
  public ChickenNodes Nodes {
    get {
      return _Nodes ??= new ChickenNodes(this);
    }
  }
}
