using Godot;
namespace ld56;

public partial class ListOfCreatures : HBoxContainer {
  public static ListOfCreatures New() {
    return GD.Load<PackedScene>("res://list_of_people.tscn").Instantiate<ListOfCreatures>();
  }
  public ListOfCreatures() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class ListOfCreaturesNodes {
    ListOfCreatures parent;

    public ListOfCreaturesNodes(ListOfCreatures parent) {
      this.parent = parent;
    }
  }

  public ListOfCreaturesNodes? _Nodes;
  public ListOfCreaturesNodes Nodes {
    get {
      return _Nodes ??= new ListOfCreaturesNodes(this);
    }
  }
}
