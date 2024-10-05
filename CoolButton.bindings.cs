using Godot;


public partial class CoolButton : Button {
  public static CoolButton New() {
    return GD.Load<PackedScene>("res://CoolButton.tscn").Instantiate<CoolButton>();
  }
  public CoolButton() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class CoolButtonNodes {
    CoolButton parent;

    public CoolButtonNodes(CoolButton parent) {
      this.parent = parent;
    }
  }

  public CoolButtonNodes? _Nodes;
  public CoolButtonNodes Nodes {
    get {
      return _Nodes ??= new CoolButtonNodes(this);
    }
  }
}
