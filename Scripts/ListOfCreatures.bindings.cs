using Godot;
namespace ld56;

public partial class ListOfCreatures : HBoxContainer {
  public static ListOfCreatures New() {
    return GD.Load<PackedScene>("res://Scenes/list_of_creatures.tscn").Instantiate<ListOfCreatures>();
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
    private UpcomingCreatureUi? _Person;
    public UpcomingCreatureUi Person {
      get => _Person ??= parent.GetNode<UpcomingCreatureUi>("Person");
    }

    private UpcomingCreatureUi? _Person2;
    public UpcomingCreatureUi Person2 {
      get => _Person2 ??= parent.GetNode<UpcomingCreatureUi>("Person2");
    }

    private UpcomingCreatureUi? _Person3;
    public UpcomingCreatureUi Person3 {
      get => _Person3 ??= parent.GetNode<UpcomingCreatureUi>("Person3");
    }

    private UpcomingCreatureUi? _Person4;
    public UpcomingCreatureUi Person4 {
      get => _Person4 ??= parent.GetNode<UpcomingCreatureUi>("Person4");
    }

    private UpcomingCreatureUi? _Person5;
    public UpcomingCreatureUi Person5 {
      get => _Person5 ??= parent.GetNode<UpcomingCreatureUi>("Person5");
    }

  }

  public ListOfCreaturesNodes? _Nodes;
  public ListOfCreaturesNodes Nodes {
    get {
      return _Nodes ??= new ListOfCreaturesNodes(this);
    }
  }
}
