using System;
using System.Collections.Generic;

namespace BlazorAppWithNils.Models;

public partial class Cpr
{
    public int Cprid { get; set; }

    public string User { get; set; } = null!;

    public string CprNr { get; set; } = null!;

    public virtual ICollection<TodoList> TodoLists { get; set; } = new List<TodoList>();
}
