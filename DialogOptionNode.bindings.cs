using Godot;


public partial class DialogOptionNode : Label {
  public static DialogOptionNode New() {
    return GD.Load<PackedScene>("res://dialog_option_node.tscn").Instantiate<DialogOptionNode>();
  }
  public DialogOptionNode() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class DialogOptionNodeNodes {
    DialogOptionNode parent;

    public DialogOptionNodeNodes(DialogOptionNode parent) {
      this.parent = parent;
    }
  }

  public DialogOptionNodeNodes? _Nodes;
  public DialogOptionNodeNodes Nodes {
    get {
      return _Nodes ??= new DialogOptionNodeNodes(this);
    }
  }
}
